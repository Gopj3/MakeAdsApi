using AutoMapper;
using MakeAdsApi.Application.Mappers.Extensions;
using MakeAdsApi.Application.MediaLibraryFiles.Shared.Models;
using MakeAdsApi.Domain.Entities.Files.MediaLibrary;

namespace MakeAdsApi.Application.Mappers.Profiles;

public class MediaLibraryFilesProfile: Profile
{
    public MediaLibraryFilesProfile()
    {
        CreateMap<MediaLibraryImage, MediaLibraryImageViewModel>().IgnoreUpdatedAt().CreatedAtToLongDateString();
        CreateMap<MediaLibraryVideo, MediaLibraryVideoViewModel>().IgnoreUpdatedAt().CreatedAtToLongDateString();
    }
}