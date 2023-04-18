using EMS.Application.Core;
using EMS.Domain.Repositories;
using Entities;
using MediatR;
using System.Net;

namespace EMS.Application.Services.Events.Commands
{
    public class DeleteEvent
    {
        public class Command : IRequest<Result<Unit>>
        {
            public Guid Id { get; set; }
        }

        public class Handler : IRequestHandler<Command, Result<Unit>>
        {
            private readonly IEventsRepository _eventsRepository;
            public Handler(IEventsRepository eventsRepository)
            {
                _eventsRepository = eventsRepository;
            }

            public async Task<Result<Unit>> Handle(Command request, CancellationToken cancellationToken)
            {
                Event? currentEvent = await _eventsRepository.GetEventById(request.Id);
                if (currentEvent != null)
                {
                  int dbStateChanges =  await _eventsRepository.DeleteEvent(currentEvent);
                    if (dbStateChanges > 0) return Result<Unit>.Success(HttpStatusCode.OK);
                    return Result<Unit>.Failure(HttpStatusCode.BadRequest,"Failed to delete event");
                }
                else return Result<Unit>.Failure(HttpStatusCode.NotFound, "Event not found");



            }
        }
    }
}
