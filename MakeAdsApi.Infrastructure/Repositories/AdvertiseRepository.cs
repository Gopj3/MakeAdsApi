using MakeAdsApi.Application.Common.Abstractions.Repositories;
using MakeAdsApi.Domain.Entities.Ads;

namespace MakeAdsApi.Infrastructure.Repositories;

public class AdvertiseRepository: GenericRepository<Advertise>, IAdvertiseRepository
{
    public AdvertiseRepository(MakeAdsDbContext context) : base(context)
    {
    }
}