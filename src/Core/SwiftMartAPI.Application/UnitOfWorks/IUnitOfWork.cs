using SwiftMartAPI.Application.Interfaces.Repositories;
using SwiftMartAPI.Domain.Common;

namespace SwiftMartAPI.Application.UnitOfWorks;

public interface IUnitOfWork:IAsyncDisposable
{

    IReadRepository<T> GetReadRepository<T>() where T : class,IEntityBase;
    IWriteRepository<T> GetWriteRepository<T>() where T : class,IEntityBase;
    Task<int> SaveAsync();
    int Save();
}
