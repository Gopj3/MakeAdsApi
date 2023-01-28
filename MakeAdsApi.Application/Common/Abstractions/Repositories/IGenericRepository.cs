using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using MakeAdsApi.Application.Common.Abstractions.Specifications;
using MakeAdsApi.Application.Common.ViewModels;

namespace MakeAdsApi.Application.Common.Abstractions.Repositories;

public interface IGenericRepository<T> where T : class
{
    Task CreateAsync(T obj, CancellationToken token = default);
    Task<T?> GetByIdAsync(Guid id, CancellationToken token = default);
    Task<List<T>> GetAllAsync(CancellationToken token = default);

    Task<PagedList<T>> GetEntitiesPaginatedAsync(
        int page,
        int pageSize,
        Expression<Func<T, bool>>? filter = null,
        CancellationToken token = default
    );

    Task<List<T>> GetByExpressionAsync(Expression<Func<T, bool>> filter, CancellationToken token = default);
    Task<T?> GetByExpressionFirstAsync(Expression<Func<T, bool>> filter, CancellationToken token = default);
    Task DeleteById(Guid id, CancellationToken token = default);
    void Delete(T entity);
    void Update(T entity);
    Task<List<T>> GetBySpecification(ISpecification<T> specification = null);
    Task<int> CountAsync(CancellationToken token = default);
}