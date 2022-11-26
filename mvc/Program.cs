using mvc.Configurations.Extensions;
using Serilog;

Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Debug()
    .WriteTo.Console()
    .WriteTo.File("Logs/mvc-logs.txt", rollingInterval: RollingInterval.Day)
    .CreateLogger();

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseSerilog();

builder.ConfigurePersistence();

builder.ConfigureAutoMapper();

builder.ConfigureControllers();

builder.ConfigureSwagger();

builder.ConfigureCors();

builder.ConfigureGlobalErrorHandler();

var app = builder.Build();

app.UseGlobalErrorHandler();

app.UseSwagger();

app.UseRouting();

app.UseCors();

app.UseEndpoints();

app.Run();
