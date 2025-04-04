﻿using Microsoft.EntityFrameworkCore.Query;
using SwiftMartAPI.Domain.Common;
using System.Linq.Expressions;

namespace SwiftMartAPI.Application.Interfaces.Repositories;

public interface IWriteRepository<T> where T : class, IEntityBase
{
    Task<bool> AddAsync(T entity);
    Task AddRangeAsync(IEnumerable<T> entities);
    bool Update(T entity);
    bool HardDelete(T entity);
    void HardRangeDelete(IEnumerable<T> entity);
    bool SoftDelete(T entity);
}
