using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using MakeAdsApi.Application.Common.Abstractions.Repositories;
using MakeAdsApi.Application.Common.Abstractions.Specifications;
using MakeAdsApi.Application.Common.ViewModels;
using MakeAdsApi.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace MakeAdsApi.Infrastructure.Repositories;

public class GenericRepository<T> : IGenericRepository<T>
    where T : BaseEntity
{
    protected readonly MakeAdsDbContext Context;
    private readonly DbSet<T> _dbSet;

    public GenericRepository(MakeAdsDbContext context)
    {
        Context = context;
        _dbSet = context.Set<T>();
    }

    public async Task CreateAsync(T entity, CancellationToken token = default)
    {
        await _dbSet.AddAsync(entity, token);
    }

    public virtual async Task<T?> GetByIdAsync(Guid id, CancellationToken token = default)
    {
        return await _dbSet.Where(x => x.Id == id).FirstOrDefaultAsync(token);
    }

    public async Task<List<T>> GetAllAsync(CancellationToken token = default)
    {
        return await _dbSet.ToListAsync(token);
    }

    public virtual async Task<PagedList<T>> GetEntitiesPaginatedAsync(
        int page,
        int pageSize,
        Expression<Func<T, bool>>? filter = null,
        CancellationToken token = default
    )
    {
        var query = _dbSet.AsQueryable();
        
        if (filter is not null)
        {
            query = query.Where(filter);
        }
        
        return await PagedList<T>.ToPagedListAsync(query, page, pageSize, token);
    }

    public async Task<List<T>> GetByExpressionAsync(Expression<Func<T, bool>> filter, CancellationToken token = default)
    {
        return await _dbSet.Where(filter).ToListAsync(token);
    }

    public virtual async Task<T?> GetByExpressionFirstAsync(Expression<Func<T, bool>> filter,
        CancellationToken token = default)
    {
        return await _dbSet.Where(filter).FirstOrDefaultAsync(token);
    }

    public async Task<int> CountAsync(CancellationToken token = default)
    {
        return await _dbSet.CountAsync();
    }

    public async Task DeleteByIdAsync(Guid id, CancellationToken token = default)
    {
        T? entity = await GetByIdAsync(id, token);

        if (entity is not null)
        {
            Delete(entity);
        }
    }

    public void Update(T entity)
    {
        Context.Entry(entity).State = EntityState.Modified;
        _dbSet.Update(entity);
    }

    public void Delete(T entity)
    {
        if (Context.Entry(entity).State == EntityState.Detached)
        {
            _dbSet.Attach(entity);
        }

        _dbSet.Remove(entity);
    }

    public Task<List<T>> GetBySpecification(ISpecification<T> specification = null)
    {
        throw new NotImplementedException();
    }
}