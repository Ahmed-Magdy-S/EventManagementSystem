using EMS.Application.Core;
using EMS.Domain.Repositories;
using Entities;
using MediatR;
using System.Net;

namespace EMS.Application.Services.Events.Queries
{
    public class EventList
    {
        public class Query : IRequest<Result<List<Event>>>{}

        public class Handler : IRequestHandler<Query,Result<List<Event>>>
        {
            private readonly IEventsRepository _eventsRepository;
            public Handler(IEventsRepository eventsRepository)
            { 
                _eventsRepository = eventsRepository;
            }
            public async Task<Result<List<Event>>> Handle(Query request, CancellationToken cancellationToken)
            {
                var events = await _eventsRepository.GetEventList();
                return Result<List<Event>>.Success(HttpStatusCode.OK,events);

            }
        }

    }
}
