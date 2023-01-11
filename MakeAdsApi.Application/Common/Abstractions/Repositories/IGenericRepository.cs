using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MakeAdsApi.Application.Common.Abstractions.Specifications;

namespace MakeAdsApi.Application.Common.Abstractions.Repositories;

public interface IGenericRepository<T> where T: class
{
    Task Create(T obj, CancellationToken token = default);
    Task<T?> GetByIdAsync(Guid id, CancellationToken token = default);
    Task<List<T>> GetAllAsync(CancellationToken token = default);
    Task<List<T>> GetEntitiesPaginated(int page, int pageSize, CancellationToken token = default);
    Task DeleteById(Guid id, CancellationToken token = default);
    void Delete(T entity);
    Task<List<T>> GetBySpecification(ISpecification<T> specification = null);
}