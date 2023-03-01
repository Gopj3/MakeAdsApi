using System;
using MakeAdsApi.Application.Common.ViewModels;

namespace MakeAdsApi.Application.MediaLibraryFiles.Shared.Models;

public abstract class MediaLibraryFileViewModel: BaseViewModel
{
    public Guid PropertyId { get; set; }
    public Guid? UserId { get; set; }
    public string FileName { get; set; }
    public string PreSignedUrl { get; set; }
}