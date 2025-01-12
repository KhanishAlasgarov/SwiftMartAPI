using Microsoft.Extensions.DependencyInjection;
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

        services.AddAutoMapper(Assembly.GetExecutingAssembly());

        return services;

    }
}
