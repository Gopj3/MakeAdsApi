using System;
using MakeAdsApi.Domain.Entities.Files;

namespace MakeAdsApi.Domain.Entities.Users;

public class UserProfile : BaseEntity
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string? Title { get; set; }
    public string? Phone { get; set; } = null;
    public UserProfileAvatar? Avatar { get; set; }
    public User User { get; set; }
    public Guid UserId { get; set; }
}