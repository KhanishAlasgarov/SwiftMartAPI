using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SwiftMartAPI.Application.Interfaces.Repositories;
using SwiftMartAPI.Persistance.Contexts;
using SwiftMartAPI.Persistance.Repositories;

namespace SwiftMartAPI.Persistance;

public static class PersistanceServiceRegistration
{
    public static IServiceCollection AddPersistanceService(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<AppDbContext>(opt =>
        {
            opt.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
        });

        services.AddScoped(typeof(IReadRepository<>), typeof(ReadRepository<>));
        services.AddScoped(typeof(IWriteRepository<>), typeof(WriteRepository<>));
        return services;
    }
}
