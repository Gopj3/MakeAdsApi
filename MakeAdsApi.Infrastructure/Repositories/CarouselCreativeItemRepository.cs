using MakeAdsApi.Application.Common.Abstractions.Repositories;
using MakeAdsApi.Domain.Entities.Ads.Creatives;

namespace MakeAdsApi.Infrastructure.Repositories;

public class CarouselCreativeItemRepository: GenericRepository<CarouselCreativeItem>, ICarouselCreativeItemRepository
{
    public CarouselCreativeItemRepository(MakeAdsDbContext context) : base(context)
    {
    }
}