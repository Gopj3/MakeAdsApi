using MakeAdsApi.Application.Common.Abstractions.Repositories;
using MakeAdsApi.Domain.Entities.Users;

namespace MakeAdsApi.Infrastructure.Repositories;

public class RoleRepository: GenericRepository<Role>, IRoleRepository
{
    public RoleRepository(MakeAdsDbContext context) : base(context)
    {
    }
}