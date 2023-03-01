using MakeAdsApi.Application.Common.Abstractions.Repositories;
using MakeAdsApi.Domain.Entities.Files.MediaLibrary;

namespace MakeAdsApi.Infrastructure.Repositories;

public class MediaLibraryImageRepository : GenericRepository<MediaLibraryImage>, IMediaLibraryImageRepository
{
    public MediaLibraryImageRepository(MakeAdsDbContext context) : base(context)
    {
    }
}