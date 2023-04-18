using System.Text.Json;
using EMS.Application.Core;

namespace EMS.API.Middlewares
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionMiddleware> _logger;
        private readonly IHostEnvironment _env;
        public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger , IHostEnvironment env)
        {
            _next = next;
            _logger = logger;
            _env = env;
        }


        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex,ex.Message);
                context.Response.ContentType = "application/json";
                context.Response.StatusCode = 500;

                var res = _env.IsDevelopment() ? new AppException(context.Response.StatusCode, ex.Message, ex.StackTrace):
                    new AppException(context.Response.StatusCode, "Server Error");

                var json = JsonSerializer.Serialize(res);

                await context.Response.WriteAsync(json);
            }
        }

    }
}
