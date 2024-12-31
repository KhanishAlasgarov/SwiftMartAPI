using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using SwiftMartAPI.Application.Interfaces.Repositories;
using SwiftMartAPI.Domain.Common;
using SwiftMartAPI.Persistance.Contexts;

namespace SwiftMartAPI.Persistance.Repositories;

public class WriteRepository<T> : IWriteRepository<T> where T : class, IEntityBase
{
    private AppDbContext _context { get; }
    protected DbSet<T> Table => _context.Set<T>();

    public WriteRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<bool> AddAsync(T entity)
    {
        EntityEntry<T> entityEntry = await Table.AddAsync(entity);
        return entityEntry.State == EntityState.Added;
    }

    public async Task AddRangeAsync(IEnumerable<T> entities)
    {
        await Table.AddRangeAsync(entities);
    }

    public bool Update(T entity)
    {
        EntityEntry<T> entityEntry = Table.Update(entity);
        return entityEntry.State == EntityState.Modified;
    }

    public bool HardDelete(T entity)
    {
        EntityEntry<T> entityEntry = Table.Remove(entity);
        return entityEntry.State == EntityState.Deleted;
    }

    public bool SoftDelete(T entity)
    {
        entity.IsDeleted = true;
        return Update(entity);
    }


}
