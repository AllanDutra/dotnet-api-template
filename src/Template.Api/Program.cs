using Template.Api.Extensions;
using Template.Api.Middlewares;
using Template.Application;
using Template.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

// ? To add swagger
builder.Services.AddEndpointsApiExplorer();

builder
    .Services.AddSwaggerExtensions()
    .AddValidators()
    .AddMiddlewares()
    .AddApplicationModule()
    .AddInfrastructureModule()
    .AddDomainModule();

var app = builder.Build();

app.UseSwagger();

app.UseSwaggerUI();

app.UseMiddleware<GlobalExceptionMiddleware>();

app.UseHttpsRedirection();

app.MapControllers();

app.Run();
