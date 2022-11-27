using Serilog;

namespace mvc.Configurations.Extensions;

public static class WebApplicationBuilderAddLoggingExtension
{
    public static WebApplicationBuilder AddLogging(this WebApplicationBuilder builder)
    {
        Log.Logger = new LoggerConfiguration()
            .MinimumLevel.Debug()
            .WriteTo.Console()
            .WriteTo.File("Logs/mvc-logs.txt", rollingInterval: RollingInterval.Day)
            .CreateLogger();

        builder.Host.UseSerilog();

        return builder;
    }
}