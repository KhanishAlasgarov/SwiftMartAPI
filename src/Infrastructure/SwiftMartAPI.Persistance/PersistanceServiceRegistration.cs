using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SwiftMartAPI.Application.Interfaces.Repositories;
using SwiftMartAPI.Application.UnitOfWorks;
using SwiftMartAPI.Domain.Entities;
using SwiftMartAPI.Persistance.Contexts;
using SwiftMartAPI.Persistance.Repositories;
using SwiftMartAPI.Persistance.UnitOfWorks;

namespace SwiftMartAPI.Persistance;

public static class PersistanceServiceRegistration
{
    public static IServiceCollection AddPersistanceService(this IServiceCollection services, IConfiguration configuration)
    {
        
        
        services.AddDbContext<AppDbContext>(opt =>
        {
            opt.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
        });
        
        services.AddIdentityCore<User>(options =>
        {
            options.Password.RequiredLength = 8;
            options.Password.RequireNonAlphanumeric = true;
            options.Password.RequireUppercase = true;
            options.Password.RequireDigit = true;
            options.SignIn.RequireConfirmedEmail = false;
            
        }).AddRoles<Role>().AddEntityFrameworkStores<AppDbContext>();

        services.AddScoped(typeof(IReadRepository<>), typeof(ReadRepository<>));
        services.AddScoped(typeof(IWriteRepository<>), typeof(WriteRepository<>));
        services.AddScoped<IUnitOfWork, UnitOfWork>();

        
        return services;
    }
}
