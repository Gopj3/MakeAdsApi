using MakeAdsApi.Application.Common.Abstractions.Repositories;
using MakeAdsApi.Domain.Entities.Users;

namespace MakeAdsApi.Infrastructure.Repositories;

public class UserRepository: GenericRepository<User>, IUserRepository
{
    public UserRepository(MakeAdsDbContext context) : base(context)
    {
    }
}