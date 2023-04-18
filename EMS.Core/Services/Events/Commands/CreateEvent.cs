using EMS.Application.Core;
using EMS.Application.Validators;
using EMS.Domain.Repositories;
using Entities;
using MediatR;
using System.Net;

namespace EMS.Application.Services.Events.Commands
{
    public class CreateEvent
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

                EventValidator validator = new();
                var result = validator.Validate(request.Event);

                if (!result.IsValid) return Result<Unit>.Failure(HttpStatusCode.BadRequest, result.ToString());

                int dbStateChanges = await _eventsRepository.AddEvent(request.Event);
                if (dbStateChanges > 0) return Result<Unit>.Success(HttpStatusCode.Created);
                return Result<Unit>.Failure(HttpStatusCode.BadRequest, "Failed to create event");
            }
        }


    }
}
