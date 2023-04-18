using EMS.Application.Services.Auth;
using EMS.Domain.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EMS.API.Controllers
{
    public class AuthController : BaseApiController
    {
        private readonly UserService _userService;
        public AuthController(UserService userService)
        {
            _userService = userService;
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<ActionResult> Login(LoginDto loginDto)
        {
            return HandleResult(await _userService.Login(loginDto));
        }

        [AllowAnonymous]
        [HttpPost("register")]
        public async Task<ActionResult> Register(RegisterDto registerDto)
        {
            return HandleResult(await _userService.Register(registerDto));
        }

   /*     [Authorize]
        [HttpGet]
        public async Task<ActionResult<UserDto>> GetCurrentUser()
        {

        }*/

    }
}
