using Microsoft.AspNetCore.Mvc;
using mvc.Configurations.Exceptions;
using System.Net;
using System.Text.Json;

namespace mvc.Configurations.Middleware;

public class GlobalExceptionHandlingMiddleware : IMiddleware
{
    private readonly ILogger<GlobalExceptionHandlingMiddleware> _logger;

    public GlobalExceptionHandlingMiddleware(ILogger<GlobalExceptionHandlingMiddleware> logger) => _logger = logger;

    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        try
        {
            await next(context);
        }
        catch (Exception exception)
        {
            await HandleExceptionAsync(context, exception);
        }
    }

    private async Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        HttpStatusCode statusCode = HttpStatusCode.InternalServerError; // 500 if unexpected

        // You might want to change this to hide/show an information for security reasons or
        // provide the one that would be more useful (contextual) for the client
        var message = "A problem happened while handling your request.";
        var stackTrace = string.Empty;

        // here you can handle specific exceptions and return a specific status code
        switch (exception)
        {
            case BadRequestApiException:
                statusCode = HttpStatusCode.BadRequest;
                // just to show how to provide information to the client if needed
                message = exception.Message;
                stackTrace = exception.StackTrace;
                break;
            case KeyNotFoundApiException or NotFoundApiException:
                statusCode = HttpStatusCode.NotFound;
                message = exception.Message;
                stackTrace = exception.StackTrace;
                break;
            case NotImplementedApiException:
                statusCode = HttpStatusCode.NotImplemented;
                message = exception.Message;
                stackTrace = exception.StackTrace;
                break;
            case UnauthorizedAccessApiException:
                statusCode = HttpStatusCode.Unauthorized;
                message = exception.Message;
                stackTrace = exception.StackTrace;
                break;
        }

        _logger.LogError(exception, $"An error occurred: {exception.Message}");

        ProblemDetails problemDetails = new()
        {
            Status = (int)statusCode,
            Type = "[Custom Middleware] Error",
            Title = message,
            Detail = stackTrace,
        };

        var resultJson = JsonSerializer.Serialize(problemDetails);

        var response = context.Response;

        response.StatusCode = (int)statusCode;

        response.ContentType = "application/json";

        await response.WriteAsync(resultJson);
    }
}