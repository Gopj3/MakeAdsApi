using System;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using MakeAdsApi.Domain.Entities.Users;

namespace MakeAdsApi.Application.Common.Abstractions.Repositories;

public interface IUserRepository: IGenericRepository<User>
{
    Task<User?> GetByExpressionWithRolesAsync(Expression<Func<User, bool>> filter, CancellationToken token = default);
}