using FluentValidation.AspNetCore;
using Newtonsoft.Json;
using SwiftMartAPI.Application;
using SwiftMartAPI.Application.Exceptions;
using SwiftMartAPI.Application.Filters;
using SwiftMartAPI.Infrastructure;
using SwiftMartAPI.Persistance;
var builder = WebApplication.CreateBuilder(args);





builder.Services
    .AddControllers(opt => opt.Filters.Add<ValidationFilter>())
    .ConfigureApiBehaviorOptions(options => options.SuppressModelStateInvalidFilter = true)
    .AddNewtonsoftJson(cfg => cfg.SerializerSettings.NullValueHandling = NullValueHandling.Ignore);

builder.Services.AddFluentValidationAutoValidation(cfg =>
{
    cfg.DisableDataAnnotationsValidation = true;
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var env = builder.Environment;

builder.Configuration
    .SetBasePath(env.ContentRootPath)
    .AddJsonFile("appsettings.json", optional: false)
    .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true);

builder.Services
    .AddPersistanceService(builder.Configuration)
    .AddApplicationService().AddInfrastructureService(builder.Configuration);
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.ConfigureExceptionHandlingMiddleware();
app.UseAuthorization();

app.MapControllers();

app.Run();
