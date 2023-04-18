using EMS.Application.Identity;
using EMS.Application.Services.Auth;
using Entities;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace EMS.API.Extensions
{
    public static class IdentityService
    {
        public static void AddIdentityService(this IServiceCollection services)
        {
            services.AddIdentityCore<AppUser>((options) =>
            {
                options.Password.RequireNonAlphanumeric = false;
            }).AddEntityFrameworkStores<ApplicationDbContext>();
            services.AddScoped<UserService>();
            services.AddScoped<TokenService>();


            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
            {
                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("Some secret key"));

                options.TokenValidationParameters = new()
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = key,
                    ValidateIssuer = false,
                    ValidateAudience = false,
                };
            });
        
        }
    }
}
