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

    public UserProfile(Guid id, string firstName, string lastName, string? title, string? phone,
        UserProfileAvatar? avatar, Guid userId)
    {
        Id = id;
        FirstName = firstName;
        LastName = lastName;
        Title = title;
        Phone = phone;
        Avatar = avatar;
        UserId = userId;
    }

    public void Update(
        string firstName,
        string lastName,
        string? title,
        string? phone,
        UserProfileAvatar? avatar
    )
    {
        FirstName = firstName;
        LastName = lastName;
        Title = title;
        Phone = phone;
        Avatar = avatar;
    }
}