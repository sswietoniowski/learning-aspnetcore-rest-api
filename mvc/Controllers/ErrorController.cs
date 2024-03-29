﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace mvc.Controllers;

[ApiController]
public class ErrorController : ControllerBase
{
    // this implementation is based on the following article: 
    // https://learn.microsoft.com/en-us/aspnet/core/web-api/handle-errors?view=aspnetcore-7.0

    private readonly ILogger<ErrorController> _logger;

    private Exception? Exception => HttpContext.Features.Get<IExceptionHandlerFeature>()?.Error;

    public ErrorController(ILogger<ErrorController> logger)
    {
        _logger = logger;
    }

    private void LogException()
    {
        if (Exception is null)
        {
            return;
        }

        _logger.LogError(Exception, Exception.Message);
    }

    [Route("/error-development")]
    [ApiExplorerSettings(IgnoreApi = true)]
    [AllowAnonymous]
    public IActionResult HandleErrorInDevelopment([FromServices] IHostEnvironment hostEnvironment)
    {
        LogException();
        
        if (!hostEnvironment.IsDevelopment())
        {
            return NotFound();
        }

        return Problem(
            statusCode: StatusCodes.Status500InternalServerError,
            type: "[ErrorController] Error",
            detail: Exception?.StackTrace,
            title: Exception?.Message);
    }

    [Route("/error")]
    [ApiExplorerSettings(IgnoreApi = true)]
    [AllowAnonymous]
    public IActionResult HandleErrorInProduction()
    {
        LogException();

        return Problem();
    }
}