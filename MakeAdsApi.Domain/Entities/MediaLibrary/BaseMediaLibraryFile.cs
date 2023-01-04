using System;
using System.ComponentModel.DataAnnotations;
using MakeAdsApi.Domain.Entities.Users;

namespace MakeAdsApi.Domain.Entities.MediaLibrary;

public abstract class BaseMediaLibraryFile: BaseEntity
{
    [Required]
    public string ExternalUrl { get; set; }
    [Required]
    public Guid UserId { get; set; }
    [Required]
    public User User { get; set; }
}