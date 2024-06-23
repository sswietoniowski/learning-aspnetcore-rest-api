using Serilog;

namespace mvc.Configurations.Extensions;

public static class WebApplicationBuilderAddLoggingExtension
{
    private static void ConfigureSerilog()
    {
        Log.Logger = new LoggerConfiguration()
            .MinimumLevel.Debug()
            .WriteTo.Console()
            .WriteTo.File("Logs/mvc-logs.txt", rollingInterval: RollingInterval.Day)
            .CreateLogger();
    }

    public static WebApplicationBuilder AddLogging(this WebApplicationBuilder builder)
    {
        ConfigureSerilog();

        builder.Host.UseSerilog();

        return builder;
    }
}