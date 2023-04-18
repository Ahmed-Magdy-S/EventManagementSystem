using Entities;

namespace EMS.Domain.Repositories
{
    public interface IEventsRepository
    {
        Task<List<Event>> GetEventList();
        Task<Event?> GetEventById(Guid id);
        Task<int> AddEvent(Event eventObj);
        Task<int> UpdateEvent(Event updatedEvent);
        Task<int> DeleteEvent(Event eventObj);

    }
}
