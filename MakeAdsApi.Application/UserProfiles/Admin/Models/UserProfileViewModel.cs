using MakeAdsApi.Application.Common.ViewModels;
using MakeAdsApi.Domain.Entities.Users;

namespace MakeAdsApi.Application.UserProfiles.Admin.Models;

public class UserProfileViewModel: BaseViewModel
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string? Title { get; set; }
    public string? Phone { get; set; }
    public string? Avatar { get; set; }

    public static UserProfileViewModel From(UserProfile userProfile)
    {
        return new UserProfileViewModel
        {
            Id = userProfile.Id,
            FirstName = userProfile.FirstName,
            LastName = userProfile.LastName,
            Title = userProfile.Title,
            Phone = userProfile.Phone,
            Avatar = userProfile.Avatar?.PreSignedUrl,
        };
    }
}