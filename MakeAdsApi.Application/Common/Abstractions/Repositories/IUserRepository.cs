using System;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using MakeAdsApi.Application.Common.ViewModels;
using MakeAdsApi.Domain.Entities.Users;

namespace MakeAdsApi.Application.Common.Abstractions.Repositories;

public interface IUserRepository: IGenericRepository<User>
{
    Task<User?> GetByExpressionWithRolesAsync(Expression<Func<User, bool>> filter, CancellationToken token = default);

    Task<PagedList<User>> GetPaginatedWithSearchAsync(int page, int pageSize, string? search = null,
        CancellationToken cancellationToken = default);
}