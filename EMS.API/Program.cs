using EMS.API.Extensions;
using EMS.API.Middlewares;
using EMS.Application;
using EMS.Domain.Repositories;
using EMS.Infrastructure.Repositories;
using Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.EntityFrameworkCore;

namespace EMS.API
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers(options =>
            {
                var policy = new AuthorizationPolicyBuilder().RequireAuthenticatedUser().Build();
                options.Filters.Add(new AuthorizeFilter(policy));
            });


            builder.Services.AddFluentValidators();
            builder.Services.AddIdentityService();

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddDbContext<ApplicationDbContext>((options) =>
            {
                options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")); 
            });

            builder.Services.AddScoped<IEventsRepository, EventsRepository>();

            builder.Services.AddMediatR(config => {
                config.RegisterServicesFromAssembly(typeof(EMSApplicationEntryPoint).Assembly);
            });

            builder.Services.AddCors(options =>
            {
                options.AddPolicy(name: "ReactDev", policy =>
                {
                    policy.WithOrigins("http://localhost:3000");
                });
            });

            var app = builder.Build();

            app.UseMiddleware<ExceptionMiddleware>();

            app.UseCors("ReactDev");

            app.UseAuthentication();
            app.UseAuthorization();


            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.MapControllers();

            await app.EnsureSeedingData();

            app.Run();
        }
    }
}