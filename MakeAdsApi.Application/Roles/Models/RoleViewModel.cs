using MakeAdsApi.Application.Common.ViewModels;
using MakeAdsApi.Domain.Entities.Users;

namespace MakeAdsApi.Application.Roles.Models;

public class RoleViewModel: BaseViewModel
{
    public string Title { get; set; }

    public static RoleViewModel From(Role role)
    {
        return new()
        {
            Id = role.Id,
            Title = role.Title,
        };
    }
}