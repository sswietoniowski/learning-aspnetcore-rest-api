using mvc.Exceptions;
using System.Net;
using System.Text.Json;
using KeyNotFoundException = mvc.Exceptions.KeyNotFoundException;
using NotImplementedException = mvc.Exceptions.NotImplementedException;
using UnauthorizedAccessException = mvc.Exceptions.UnauthorizedAccessException;

namespace mvc.Configurations.Middleware;

public class GlobalExceptionHandlingMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<GlobalExceptionHandlingMiddleware> _logger;

    public GlobalExceptionHandlingMiddleware(RequestDelegate next, ILogger<GlobalExceptionHandlingMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }
    
    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception exception)
        {
            await HandleExceptionAsync(context, exception);
        }
    }

    private async Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        context.Response.ContentType = "application/json";
        var response = context.Response;
        
        HttpStatusCode statusCode = HttpStatusCode.InternalServerError; // 500 if unexpected

        // You might want to change this to hide/show an information for security reasons or
        // provide the one that would be more useful (contextual) for the client
        var message = "A problem happened while handling your request.";
        var stackTrace = string.Empty;

        // here you can handle specific exceptions and return a specific status code
        switch (exception)
        {
            case BadRequestException:
                statusCode = HttpStatusCode.BadRequest;
                // just to show how to provide information to the client if needed
                message = exception.Message;
                stackTrace = exception.StackTrace;
                break;
            case KeyNotFoundException or NotFoundException:
                statusCode = HttpStatusCode.NotFound;
                message = exception.Message;
                stackTrace = exception.StackTrace;
                break;
            case NotImplementedException:
                statusCode = HttpStatusCode.NotImplemented;
                message = exception.Message;
                stackTrace = exception.StackTrace;
                break;
            case UnauthorizedAccessException:
                statusCode = HttpStatusCode.Unauthorized;
                message = exception.Message;
                stackTrace = exception.StackTrace;
                break;
        }

        _logger.LogError($"An exception occurred: {exception}");

        var exceptionResult = JsonSerializer.Serialize(new { Error = message, StackTrace = stackTrace });

        //response.StatusCode = (int)statusCode;

        await response.WriteAsync(exceptionResult);
    }
}