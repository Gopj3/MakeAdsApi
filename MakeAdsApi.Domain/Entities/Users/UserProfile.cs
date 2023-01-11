using System;

namespace MakeAdsApi.Domain.Entities.Users;

public class UserProfile : BaseEntity
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string? Title { get; set; } = null;
    public string? Avatar { get; set; } = null;
    public string? Phone { get; set; } = null;
    public User User { get; set; }
    public Guid UserId { get; set; }
}