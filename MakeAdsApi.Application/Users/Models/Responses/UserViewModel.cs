using System;
using System.Collections.Generic;
using System.Linq;
using MakeAdsApi.Application.Common.ViewModels;
using MakeAdsApi.Application.Roles.Models;
using MakeAdsApi.Application.UserProfiles.Admin.Models;
using MakeAdsApi.Domain.Entities.Users;

namespace MakeAdsApi.Application.Users.Models.Responses;

public class UserViewModel : BaseViewModel
{
    public string Email { get; set; }
    public Guid? OfficeId { get; set; }
    public List<RoleViewModel>? Roles { get; set; }
    
    public UserProfileViewModel? Profile { get; set; }

    public static UserViewModel From(User user)
    {
        return new UserViewModel
         {
             Id = user.Id,
             Email = user.Email,
             Roles = user.UserRoles?.Select(x => RoleViewModel.From(x.Role)).ToList(),
             Profile = user.Profile != null ? UserProfileViewModel.From(user.Profile) : null,
             OfficeId = user.OfficeId,
             CreatedAt = user.CreatedAt.ToLongDateString()
         };
    }
}