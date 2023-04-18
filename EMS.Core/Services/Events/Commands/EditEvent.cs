using EMS.Application.Core;
using EMS.Domain.Repositories;
using Entities;
using MediatR;
using System.Net;

namespace EMS.Application.Services.Events.Commands
{
    public class UpdateEvent
    {
        public class Command : IRequest<Result<Unit>>
        {
            public required Event Event { get; set; }
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
                int dbStateChnages = await _eventsRepository.UpdateEvent(request.Event);

                if (dbStateChnages > 0) return Result<Unit>.Success(HttpStatusCode.OK);

                return Result<Unit>.Failure(HttpStatusCode.BadRequest, "Faild to update event ");
            }
        }


    }
}
