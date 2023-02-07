using MakeAdsApi.Application.Common.Abstractions.Repositories;
using MakeAdsApi.Domain.Entities.Ads.Creatives;

namespace MakeAdsApi.Infrastructure.Repositories;

public class CarouselCreativeRepository: GenericRepository<CarouselCreative>, ICarouselCreativeRepository
{
    public CarouselCreativeRepository(MakeAdsDbContext context) : base(context)
    {
    }
}