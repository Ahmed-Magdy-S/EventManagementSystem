using Entities;
using FluentValidation;

namespace EMS.Application.Validators
{
    public class EventValidator : AbstractValidator<Event> 
    {
        public EventValidator()
        {
            RuleFor(e => e.Title).NotEmpty();
            RuleFor(e => e.Description).NotEmpty();
            RuleFor(e => e.City).NotEmpty();
            RuleFor(e => e.Place).NotEmpty();
            RuleFor(e => e.Category).NotEmpty();
            RuleFor(e => e.Date).NotEmpty();

        }
    }
}
