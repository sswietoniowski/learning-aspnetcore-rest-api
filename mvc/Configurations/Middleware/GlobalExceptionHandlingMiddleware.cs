using System.Net;
using System.Text.Json;
using mvc.Exceptions;

namespace mvc.Configurations.Middleware
{
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
            _logger.LogCritical($"An exception occurred: {exception}");

            HttpStatusCode statusCode = HttpStatusCode.InternalServerError; // 500 if unexpected

            // You might want to change this to hide/show an information for security reasons or
            // provide the one that would be more useful (contextual) for the client
            var message = "A problem happened while handling your request.";
            var stackTrace = string.Empty;

            switch (exception)
            {
                case BadRequestException:
                    statusCode = HttpStatusCode.BadRequest;
                    // just to show how to show the message and stack trace if needed
                    message = exception.Message;
                    stackTrace = exception.StackTrace;
                    break;
                case mvc.Exceptions.KeyNotFoundException or NotFoundException:
                    statusCode = HttpStatusCode.NotFound;
                    message = exception.Message;
                    stackTrace = exception.StackTrace;
                    break;
                case mvc.Exceptions.NotImplementedException:
                    statusCode = HttpStatusCode.NotImplemented;
                    message = exception.Message;
                    stackTrace = exception.StackTrace;
                    break;
                case mvc.Exceptions.UnauthorizedAccessException:
                    statusCode = HttpStatusCode.Unauthorized;
                    message = exception.Message;
                    stackTrace = exception.StackTrace;
                    break;
            }

            var exceptionResult = JsonSerializer.Serialize(new { Error = message, StackTrace = stackTrace });

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)statusCode;
            await context.Response.WriteAsync(exceptionResult);
        }
    }
}
