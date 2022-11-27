using mvc.Configurations.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.AddLogging();
builder.AddPersistence();
builder.AddMapper();
builder.AddControllers();
builder.AddSwagger();
builder.AddCors();
builder.AddGlobalErrorHandler();

var app = builder.Build();

app.UseGlobalErrorHandler();
app.UseSwagger();
app.UseRouting();
app.UseCors();
app.UseEndpoints();

app.Run();
