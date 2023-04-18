using EMS.Domain.Repositories;
using Entities;
using Microsoft.EntityFrameworkCore;

namespace EMS.Infrastructure.Repositories
{
    public class EventsRepository : IEventsRepository
    {
        private readonly ApplicationDbContext _dbContext;
        public EventsRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Event?> GetEventById(Guid id)
        {
            return await _dbContext.Events.FindAsync(id);
        }

        public async Task<List<Event>> GetEventList()
        {
            return await _dbContext.Events.ToListAsync();
        }

        public async Task<int> AddEvent(Event Event)
        {
            _dbContext.Events.Add(Event);
            return await _dbContext.SaveChangesAsync();
        }

        public async Task<int> UpdateEvent(Event updatedEvent)
        {
            Event? currentEvent = await _dbContext.Events.FindAsync(updatedEvent.Id);

            if (currentEvent == null) throw new Exception();

            currentEvent.Title = updatedEvent.Title;

            return await _dbContext.SaveChangesAsync();




        }

        public async Task<int> DeleteEvent(Event eventObj)
        {
            _dbContext.Events.Remove(eventObj);
            return await _dbContext.SaveChangesAsync();
        }
    }
}
