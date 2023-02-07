using MakeAdsApi.Application.Common.Abstractions.Repositories;
using MakeAdsApi.Domain.Entities.Ads.AdSets;

namespace MakeAdsApi.Infrastructure.Repositories;

public class AdSetLocationRepository: GenericRepository<AdSetLocation>, IAdSetLocationRepository
{
    public AdSetLocationRepository(MakeAdsDbContext context) : base(context)
    {
    }
}