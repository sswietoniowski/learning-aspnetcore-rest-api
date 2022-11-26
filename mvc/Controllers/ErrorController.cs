using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using System;

namespace mvc.Controllers
{
    [ApiController]
    public class ErrorController : ControllerBase
    {
        // this implementation is based on the following article: 
        // https://learn.microsoft.com/en-us/aspnet/core/web-api/handle-errors?view=aspnetcore-7.0

        private readonly ILogger<ErrorController> _logger;

        public ErrorController(ILogger<ErrorController> logger)
        {
            _logger = logger;
        }

        [Route("/error-development")]
        [ApiExplorerSettings(IgnoreApi = true)]
        [AllowAnonymous]
        public IActionResult HandleErrorDevelopment([FromServices] IHostEnvironment hostEnvironment)
        {
            if (!hostEnvironment.IsDevelopment())
            {
                return NotFound();
            }

            var exception = HttpContext.Features.Get<IExceptionHandlerFeature>()?.Error;

            if (exception is not null)
            {
                _logger.LogError($"An error occurred: {exception}");
            }

            return Problem(
                detail: exception?.StackTrace,
                title: exception?.Message);
        }

        [Route("/error")]
        [ApiExplorerSettings(IgnoreApi = true)]
        [AllowAnonymous]
        public IActionResult HandleError()
        {
            var exception = HttpContext.Features.Get<IExceptionHandlerFeature>()?.Error;

            if (exception is not null)
            {
                _logger.LogError($"An error occurred: {exception}");
            }

            return Problem();
        }
    }
}
