using System;
using System.ComponentModel.DataAnnotations;
using MakeAdsApi.Domain.Entities.Users;

namespace MakeAdsApi.Domain.Entities.Files.MediaLibrary;

public abstract class BaseMediaLibraryFile : File
{
    [Required] public string RetailPropertyId { get; set; }
    [Required] public Guid UserId { get; set; }
    [Required] public User User { get; set; }

    protected BaseMediaLibraryFile(
        string fileName,
        string fileExtension,
        string? preSignedUrl
    ) : base(fileName, fileExtension, preSignedUrl)
    {
    }
}