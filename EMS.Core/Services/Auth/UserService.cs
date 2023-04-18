using EMS.Application.Core;
using EMS.Application.Identity;
using EMS.Domain.DTOs;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace EMS.Application.Services.Auth
{
    public class UserService
    {
        private readonly UserManager<AppUser > _userManager;
        private readonly TokenService _tokenService;
        public UserService(UserManager<AppUser> userManager, TokenService tokenService) 
        {
            _userManager = userManager;
            _tokenService = tokenService;
        }

        public async Task<Result<UserDto>> Login(LoginDto loginDto)
        {
            if (loginDto.Email == null || loginDto.Password == null) return Result<UserDto>.Failure(HttpStatusCode.BadRequest,"No email/password provided");
            var user = await _userManager.FindByEmailAsync(loginDto.Email);
            if (user == null) return Result<UserDto>.Failure(HttpStatusCode.BadRequest, "User Not Found");
            bool isValidPassword = await _userManager.CheckPasswordAsync(user,loginDto.Password); 

            if (!isValidPassword) return Result<UserDto>.Failure(HttpStatusCode.BadRequest, "Email/Password is invalid");

            UserDto userDto = new() {
                Name = user.Name,
                Username = user.UserName,
                Token = _tokenService.CreateToken(user)
            };

            return Result<UserDto>.Success(HttpStatusCode.OK,userDto);

        }

        public async Task<Result<UserDto>> Register(RegisterDto registerDto)
        {
            if (registerDto.Email == null || registerDto.Password == null) return Result<UserDto>.Failure(HttpStatusCode.BadRequest, "No email/password provided");
            var usernameIsExist = await _userManager.Users.AnyAsync(x=>x.UserName == registerDto.Username);
            if (usernameIsExist) return Result<UserDto>.Failure(HttpStatusCode.BadRequest, "username is already taken");

            var user = new AppUser()
            {
                Name = registerDto.Name,
                Email = registerDto.Email,
                UserName = registerDto.Username
            };

            var result = await _userManager.CreateAsync(user, registerDto.Password);

            if (!result.Succeeded) return Result<UserDto>.Failure(HttpStatusCode.InternalServerError, result.Errors.ToString()??"failed to register user");

            UserDto userDto = new()
            {
                Name = user.Name,
                Username = user.UserName,
                Token = _tokenService.CreateToken(user)
            };

            return Result<UserDto>.Success(HttpStatusCode.Created, userDto);

        }


    }
}
