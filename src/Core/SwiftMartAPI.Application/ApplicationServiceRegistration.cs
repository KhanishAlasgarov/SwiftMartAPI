using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using SwiftMartAPI.Application.Exceptions;
using System.Reflection;

namespace SwiftMartAPI.Application;

public static class ApplicationServiceRegistration
{
    public static IServiceCollection AddApplicationService(this IServiceCollection services)
    {
        services.AddMediatR(con =>
        {
            con.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly());
        });
        services.AddTransient<ExceptionMiddleware>();
        services.AddAutoMapper(Assembly.GetExecutingAssembly());

        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

        ValidatorOptions.Global.LanguageManager.Culture = new System.Globalization.CultureInfo("az");

        return services;

    }
}
