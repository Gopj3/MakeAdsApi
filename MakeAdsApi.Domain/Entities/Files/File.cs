using System;
using System.ComponentModel.DataAnnotations;

namespace MakeAdsApi.Domain.Entities.Files;

public abstract class File : BaseEntity
{
    [Required] public string FileName { get; set; }
    [Required] public string FileExtension { get; set; }
    public string? PreSignedUrl { get; set; }
    public DateTime? PreSignedUrlCreatedAt { get; set; }

    public File(string fileName, string fileExtension, string? preSignedUrl)
    {
        FileName = fileName;
        FileExtension = fileExtension;
        PreSignedUrl = preSignedUrl;
        PreSignedUrlCreatedAt = DateTime.UtcNow;
    }

    public virtual void Update(
        string fileName,
        string fileExtension,
        string preSignedUrl
    )
    {
        FileName = fileName;
        FileExtension = fileExtension;
        PreSignedUrl = preSignedUrl;
        PreSignedUrlCreatedAt = DateTime.UtcNow;
    }
}