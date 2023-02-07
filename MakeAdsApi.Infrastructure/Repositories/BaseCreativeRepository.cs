using MakeAdsApi.Application.Common.Abstractions.Repositories;
using MakeAdsApi.Domain.Entities.Ads.Creatives;

namespace MakeAdsApi.Infrastructure.Repositories;

public class BaseCreativeRepository: GenericRepository<BaseCreative>, IBaseCreativeRepository
{
    public BaseCreativeRepository(MakeAdsDbContext context) : base(context)
    {
    }
}