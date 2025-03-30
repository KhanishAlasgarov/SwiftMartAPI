using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using SwiftMartAPI.Application.Exceptions;
using System.Reflection;
using SwiftMartAPI.Application.Bases;
using SwiftMartAPI.Application.Features.Products.Exceptions;

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

        services.AddSubClassesOfType(Assembly.GetExecutingAssembly(), typeof(BaseRules));
        
        return services;

    }
    
    private static IServiceCollection AddSubClassesOfType(
        this IServiceCollection services,
        Assembly assembly,
        Type type,
        Func<IServiceCollection, Type, IServiceCollection>? addWithLifeCycle = null
    )
    {
        var types = assembly.GetTypes().Where(t => t.IsSubclassOf(type) && type != t).ToList();
        foreach (var item in types)
            if (addWithLifeCycle == null)
                services.AddScoped(item);
            else
                addWithLifeCycle(services, type);
        return services;
    }

}
