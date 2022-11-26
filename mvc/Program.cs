using mvc.Configurations.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.ConfigureLogging();

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
