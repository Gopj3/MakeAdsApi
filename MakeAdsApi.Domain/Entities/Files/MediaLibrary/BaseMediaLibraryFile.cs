using System;
using System.ComponentModel.DataAnnotations;
using MakeAdsApi.Domain.Entities.Properties;
using MakeAdsApi.Domain.Entities.Users;

namespace MakeAdsApi.Domain.Entities.Files.MediaLibrary;

public abstract class BaseMediaLibraryFile : File
{
    public Guid PropertyId { get; set; }
    public Property Property { get; set; }
    public Guid? UserId { get; set; }
    public User? User { get; set; }
}