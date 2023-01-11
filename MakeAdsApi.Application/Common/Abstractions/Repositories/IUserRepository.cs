using System.Threading;
using System.Threading.Tasks;
using MakeAdsApi.Domain.Entities.Users;

namespace MakeAdsApi.Application.Common.Abstractions.Repositories;

public interface IUserRepository: IGenericRepository<User>
{
    Task<User?> FindByEmailWithRolesAsync(string email, CancellationToken token = default);
}