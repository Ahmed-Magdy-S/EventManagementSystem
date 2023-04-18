using EMS.Application.Core;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace EMS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseApiController : ControllerBase
    {
        private readonly IMediator? _mediator;

        protected IMediator Mediator => _mediator ?? HttpContext.RequestServices.GetRequiredService<IMediator>();


        protected ActionResult HandleResult<T>(Result<T> result)
        {
          try
            {
                if (result.Error != null && result.StatusCode == HttpStatusCode.BadRequest) return BadRequest(result.Error);
                if (result.Error != null && result.StatusCode == HttpStatusCode.NotFound) return NotFound(result.Error);
                if (result.Value != null && result.StatusCode == HttpStatusCode.OK) return Ok(result.Value);
                if (result.Value != null && result.StatusCode == HttpStatusCode.Created) return Created("", result.Value);

                return Problem(detail: "Oops, it seems their is a unhadnled request scenario", statusCode: 500);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return Problem(detail: "Oops, it seems their is a unhadnled request scenario", statusCode: 500);

            }

        }
    }
}
