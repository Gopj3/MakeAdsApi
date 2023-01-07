using System.Threading;
using System.Threading.Tasks;
using MakeAdsApi.Domain.Entities.Users;

namespace MakeAdsApi.Application.Common.Abstractions.Repositories;

public interface IUserRepository: IGenericRepository<User>
{
    Task<User?> FindByEmailAsync(string email, CancellationToken token = default);
}