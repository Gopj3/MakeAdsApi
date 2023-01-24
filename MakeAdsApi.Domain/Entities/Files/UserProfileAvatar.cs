using System;
using MakeAdsApi.Domain.Entities.Users;

namespace MakeAdsApi.Domain.Entities.Files;

public class UserProfileAvatar: File
{
    public Guid UserProfileId { get; set; }
    public UserProfile UserProfile { get; set; }
}