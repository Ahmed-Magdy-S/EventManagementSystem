using EMS.Application.Identity;
using EMS.Infrastructure.DatabaseContext;
using Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace EMS.API.Extensions
{
    public static class DataSeed
    {
        public static async Task EnsureSeedingData(this WebApplication app)
        {

            using var scope = app.Services.CreateScope();
            var logger = scope.ServiceProvider.GetRequiredService<ILogger<Program>>();

            try
            {
                ApplicationDbContext applicationDbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
                var userManager = scope.ServiceProvider.GetRequiredService<UserManager<AppUser>>();
                await applicationDbContext.Database.MigrateAsync();
                await Seed.SeedData(applicationDbContext, userManager);
                logger.LogInformation("Database has been seeded successfully");

            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Cannot make DB migrations");
            }
        }
    }
}
