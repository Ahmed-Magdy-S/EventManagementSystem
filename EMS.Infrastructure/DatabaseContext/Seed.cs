using EMS.Application.Identity;
using Entities;
using Microsoft.AspNetCore.Identity;

namespace EMS.Infrastructure.DatabaseContext
{
    public class Seed
    {
        public static async Task SeedData(ApplicationDbContext context, UserManager<AppUser> userManager)
        {
            if (!userManager.Users.Any())
            {
                var user = new AppUser() { Name = "Ahmed", Bio = "Fullstack web developer", Email = "Ahmed.Magdy.S.19@gmail.com"};
                await userManager.CreateAsync(user, "ashram.19");
            }

            if (context.Events.Any()) return;

            var events = new List<Event>
            {
                new Event
                {
                    Title = "Past Event 1",
                    Date = DateTime.UtcNow.AddMonths(-2),
                    Description = "Event 2 months ago",
                    Category = "drinks",
                    City = "London",
                    Place = "Pub",
                },
                new Event
                {
                    Title = "Past Event 2",
                    Date = DateTime.UtcNow.AddMonths(-1),
                    Description = "Event 1 month ago",
                    Category = "culture",
                    City = "Paris",
                    Place = "Louvre",
                },
                new Event
                {
                    Title = "Future Event 1",
                    Date = DateTime.UtcNow.AddMonths(1),
                    Description = "Event 1 month in future",
                    Category = "culture",
                    City = "London",
                    Place = "Natural History Museum",
                },
                new Event
                {
                    Title = "Future Event 2",
                    Date = DateTime.UtcNow.AddMonths(2),
                    Description = "Event 2 months in future",
                    Category = "music",
                    City = "London",
                    Place = "O2 Arena",
                },
                new Event
                {
                    Title = "Future Event 3",
                    Date = DateTime.UtcNow.AddMonths(3),
                    Description = "Event 3 months in future",
                    Category = "drinks",
                    City = "London",
                    Place = "Another pub",
                },
                new Event
                {
                    Title = "Future Event 4",
                    Date = DateTime.UtcNow.AddMonths(4),
                    Description = "Event 4 months in future",
                    Category = "drinks",
                    City = "London",
                    Place = "Yet another pub",
                },
                new Event
                {
                    Title = "Future Event 5",
                    Date = DateTime.UtcNow.AddMonths(5),
                    Description = "Event 5 months in future",
                    Category = "drinks",
                    City = "London",
                    Place = "Just another pub",
                },
                new Event
                {
                    Title = "Future Event 6",
                    Date = DateTime.UtcNow.AddMonths(6),
                    Description = "Event 6 months in future",
                    Category = "music",
                    City = "London",
                    Place = "Roundhouse Camden",
                },
                new Event
                {
                    Title = "Future Event 7",
                    Date = DateTime.UtcNow.AddMonths(7),
                    Description = "Event 2 months ago",
                    Category = "travel",
                    City = "London",
                    Place = "Somewhere on the Thames",
                },
                new Event
                {
                    Title = "Future Event 8",
                    Date = DateTime.UtcNow.AddMonths(8),
                    Description = "Event 8 months in future",
                    Category = "film",
                    City = "London",
                    Place = "Cinema",
                }
            };

            context.Events.AddRange(events);
            await context.SaveChangesAsync();
        }
    }
}