using EMS.Application.Services.Events.Commands;
using EMS.Application.Services.Events.Queries;
using Entities;
using Microsoft.AspNetCore.Mvc;

namespace EMS.API.Controllers
{
    public class EventsController : BaseApiController
    {

        [HttpGet]
        public async Task<ActionResult<List<Event>>> GetAllEvents()
        {
            return HandleResult(await Mediator.Send(new EventList.Query()));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Event>> GetEventDetails(Guid id)
        {
            return HandleResult(await Mediator.Send(new EventDetails.Query { Id = id }));

        }

        [HttpPost]
        public async Task<IActionResult> CreateEvent(Event createdEvent)
        {
            return HandleResult(await Mediator.Send(new CreateEvent.Command { Event = createdEvent }));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateEvent(Guid id, Event updatedEvent)
        {
            return HandleResult(await Mediator.Send(new UpdateEvent.Command() { Event = updatedEvent }));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEvent(Guid id)
        {
            return HandleResult(await Mediator.Send(new DeleteEvent.Command { Id = id }));
        }

    }
}
