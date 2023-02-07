using MakeAdsApi.Application.Common.Abstractions.Repositories;
using MakeAdsApi.Domain.Entities.Ads.Medias;

namespace MakeAdsApi.Infrastructure.Repositories;

public class MediaRepository: GenericRepository<Media>, IMediaRepository
{
    public MediaRepository(MakeAdsDbContext context) : base(context)
    {
    }
}