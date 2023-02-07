using MakeAdsApi.Application.Common.Abstractions.Repositories;
using MakeAdsApi.Domain.Entities.Ads.Campaigns;

namespace MakeAdsApi.Infrastructure.Repositories;

public class CampaignRepository: GenericRepository<Campaign>, ICampaignRepository
{
    public CampaignRepository(MakeAdsDbContext context) : base(context)
    {
    }
}