using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SwiftMartAPI.Infrastructure.Tokens;


namespace SwiftMartAPI.Infrastructure;

public static class InfrastructureServiceRegistration
{
    public static IServiceCollection AddInfrastructureService(this IServiceCollection services,
        IConfiguration configuration)
    { 
        services.Configure<TokenSettings>(configuration.GetSection("JWT"));
        return services;
    }
}