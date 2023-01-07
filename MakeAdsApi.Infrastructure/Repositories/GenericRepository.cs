using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MakeAdsApi.Application.Common.Abstractions.Repositories;
using MakeAdsApi.Application.Common.Abstractions.Specifications;
using MakeAdsApi.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace MakeAdsApi.Infrastructure.Repositories;

public class GenericRepository<T> : IGenericRepository<T> 
    where T: BaseEntity
{
    protected readonly MakeAdsDbContext Context;
    private readonly DbSet<T> _dbSet;

    public GenericRepository(MakeAdsDbContext context)
    {
        Context = context;
        _dbSet = context.Set<T>();
    }
    
    public async Task Create(T entity, CancellationToken token = default)
    {
        await _dbSet.AddAsync(entity, token);
    }

    public async Task<T?> GetByIdAsync(Guid id, CancellationToken token = default)
    {
        return await _dbSet.Where(x => x.Id == id).FirstOrDefaultAsync(token);
    }

    public async Task<List<T>> GetAllAsync(CancellationToken token = default)
    {
        return await _dbSet.ToListAsync(token);
    }

    public async Task DeleteById(Guid id, CancellationToken token = default)
    {
        T? entity = await GetByIdAsync(id, token);

        if (entity is not null)
        {
            Delete(entity);
        }
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