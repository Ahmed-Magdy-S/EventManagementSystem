using EMS.Application.Validators;
using Entities;
using FluentValidation;

namespace EMS.API.Extensions
{
    public static class RegisterValidators
    {
        public static void AddFluentValidators (this IServiceCollection services)
        {
            services.AddScoped<IValidator<Event>, EventValidator>();
        }
    }
}
