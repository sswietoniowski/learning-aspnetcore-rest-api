using minimal;
using minimal.Configurations.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.AddPersistence();
builder.AddMapper();
builder.AddServices();
builder.AddSwagger();
builder.AddCors();
builder.AddGlobalErrorHandler();

var app = builder.Build();

app.UseGlobalErrorHandler();
app.UseSwagger();
app.UseCors();
app.UseMinimalApiEndpoints();

app.Run();
