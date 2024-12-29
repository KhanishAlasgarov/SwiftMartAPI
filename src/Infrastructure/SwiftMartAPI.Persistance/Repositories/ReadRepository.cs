using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using SwiftMartAPI.Application.Interfaces.Repositories;
using SwiftMartAPI.Domain.Common;
using System.Linq.Expressions;

namespace SwiftMartAPI.Persistance.Repositories;

public class ReadRepository<T> : IReadRepository<T> where T : class, IEntityBase
{
    public ReadRepository(DbContext context)
    {
        _context = context;
    }

    private DbContext _context { get; }
    protected DbSet<T> Table => _context.Set<T>();

    public async Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>>? predicate = null, Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null, Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null, bool enableTracking = false)
    {
        IQueryable<T> query = Table.AsQueryable();

        if (!enableTracking)
            query = query.AsNoTracking();

        if (include is not null)
            query = include(query);

        if (predicate is not null)
            query = query.Where(predicate);

        if (orderBy is not null)
            query = orderBy(query);

        return await query.ToListAsync();
    }

    public async Task<IEnumerable<T>> GetAllByPagingAsync(Expression<Func<T, bool>>? predicate = null, Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null, Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null, bool enableTracking = false, int currentPage = 1, int pageSize = 3)
    {
        IQueryable<T> query = Table.AsQueryable();

        if (!enableTracking)
            query = query.AsNoTracking();

        if (include is not null)
            query = include(query);

        if (predicate is not null)
            query = query.Where(predicate);

        if (orderBy is not null)
            query = orderBy(query);

        return await query.Skip((currentPage - 1) * pageSize).Take(pageSize).ToListAsync();
    }

    public async Task<T?> GetAsync(Expression<Func<T, bool>> predicate, Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null, bool enableTracking = false)
    {
        IQueryable<T> query = Table.AsQueryable();

        if (!enableTracking)
            query = query.AsNoTracking();

        if (include is not null)
            query = include(query);

        return await query.FirstOrDefaultAsync(predicate);
    }

    public Task<int> CountAsync(Expression<Func<T, bool>>? predicate = null)
    {
        IQueryable<T> query = Table.AsQueryable().AsNoTracking();
        if (predicate is not null)
            query = query.Where(predicate);


        return query.CountAsync();
    }

    public IQueryable<T> Find(Expression<Func<T, bool>> predicate, bool enableTracking = false)
    {
        IQueryable<T> query = Table.AsQueryable();

        if (!enableTracking)
            query = query.AsNoTracking();

        return query.Where(predicate);

    }


}
