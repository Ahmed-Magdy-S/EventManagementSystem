using EMS.Application.Core;
using EMS.Domain.Repositories;
using Entities;
using MediatR;
using System.Net;

namespace EMS.Application.Services.Events.Queries
{
    public class EventDetails
    {
        public class Query : IRequest<Result<Event>> 
        {
            public Guid Id { get; set; }
        }

        public class Handler : IRequestHandler<Query, Result<Event>>
        {
            private readonly IEventsRepository _eventsRepository;
            public Handler(IEventsRepository eventsRepository)
            {
                _eventsRepository = eventsRepository;
            }
            public async Task<Result<Event>> Handle(Query request, CancellationToken cancellationToken)
            {
                var eventDetails = await _eventsRepository.GetEventById(request.Id);
                if (eventDetails == null) return Result<Event>.Failure(HttpStatusCode.NotFound, "Event not found");
                return Result<Event>.Success(HttpStatusCode.OK, eventDetails);
            }
        }
    }
}
