using SwiftMartAPI.Application.Interfaces.Repositories;
using SwiftMartAPI.Application.UnitOfWorks;
using SwiftMartAPI.Persistance.Contexts;
using SwiftMartAPI.Persistance.Repositories;

namespace SwiftMartAPI.Persistance.UnitOfWorks;

public class UnitOfWork : IUnitOfWork
{
    public AppDbContext _context { get; set; }

    public UnitOfWork(AppDbContext context)
    {
        _context = context;
    }

    public async ValueTask DisposeAsync() => await _context.DisposeAsync();

    public int Save()
    => _context.SaveChanges();


    public async Task<int> SaveAsync()
    => await _context.SaveChangesAsync();

    IReadRepository<T> IUnitOfWork.GetReadRepository<T>()
    => new ReadRepository<T>(_context);

    IWriteRepository<T> IUnitOfWork.GetWriteRepository<T>()
    => new WriteRepository<T>(_context);
}
