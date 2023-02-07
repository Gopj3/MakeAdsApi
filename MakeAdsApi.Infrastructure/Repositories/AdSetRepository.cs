using MakeAdsApi.Application.Common.Abstractions.Repositories;
using MakeAdsApi.Domain.Entities.Ads.AdSets;

namespace MakeAdsApi.Infrastructure.Repositories;

public class AdSetRepository: GenericRepository<AdSet>, IAdSetRepository
{
    public AdSetRepository(MakeAdsDbContext context) : base(context)
    {
    }
}