using MakeAdsApi.Application.Common.Abstractions.Repositories;
using MakeAdsApi.Domain.Entities.Ads.Creatives;

namespace MakeAdsApi.Infrastructure.Repositories;

public class AbCreativeRepository: GenericRepository<ABCreative>, IABCreativeRepository
{
    public AbCreativeRepository(MakeAdsDbContext context) : base(context)
    {
    }
}