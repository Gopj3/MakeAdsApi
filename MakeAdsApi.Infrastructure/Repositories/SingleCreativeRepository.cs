using MakeAdsApi.Application.Common.Abstractions.Repositories;
using MakeAdsApi.Domain.Entities.Ads.Creatives;

namespace MakeAdsApi.Infrastructure.Repositories;

public class SingleCreativeRepository: GenericRepository<SingleCreative>, ISingleCreativeRepository
{
    public SingleCreativeRepository(MakeAdsDbContext context) : base(context)
    {
    }
}