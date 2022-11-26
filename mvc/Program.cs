using mvc.Configurations.Extensions;

var builder = WebApplication.CreateBuilder(args)
    .ConfigureLogging()
    .ConfigurePersistence()
    .ConfigureAutoMapper()
    .ConfigureControllers()
    .ConfigureSwagger()
    .ConfigureCors()
    .ConfigureGlobalErrorHandler();

var app = builder.Build();

app.UseGlobalErrorHandler();
app.UseSwagger();
app.UseRouting();
app.UseCors();
app.UseEndpoints();

app.Run();
