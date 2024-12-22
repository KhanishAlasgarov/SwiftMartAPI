using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SwiftMartAPI.Persistance.Contexts;

namespace SwiftMartAPI.Persistance;

public static class PersistanceServiceRegistration
{
    public static IServiceCollection AddPersistanceService(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<AppDbContext>(opt =>
        {
            opt.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
        });
        return services;
    }
}
