using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

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

            var exceptionHandlerFeature =
                HttpContext.Features.Get<IExceptionHandlerFeature>()!;

            _logger.LogError($"An exception occurred: {exceptionHandlerFeature?.Error}");

            return Problem(
                detail: exceptionHandlerFeature?.Error?.StackTrace,
                title: exceptionHandlerFeature?.Error?.Message);
        }

        [Route("/error")]
        [ApiExplorerSettings(IgnoreApi = true)]
        [AllowAnonymous]
        public IActionResult HandleError()
        {
            var exceptionHandlerFeature =
                HttpContext.Features.Get<IExceptionHandlerFeature>()!;

            _logger.LogError($"An exception occurred: {exceptionHandlerFeature?.Error}");

            return Problem();
        }
    }
}
