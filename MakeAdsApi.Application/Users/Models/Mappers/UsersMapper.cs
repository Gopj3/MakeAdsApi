using System.Collections.Generic;
using System.Linq;
using MakeAdsApi.Domain.Entities.Users;

namespace MakeAdsApi.Application.Users.Models.Mappers;

public static class UsersMapper
{
    public static UserDto ToDto(this User user)
    {
        return new UserDto
        {
            Id = user.Id,
            Email = user.Email,
            UserProfile = user.Profile?.ToDto()
        };
    }

    public static User ToEntity(this UserDto userDto)
    {
        return new User
        {
            Email = userDto.Email,
            Profile = userDto.UserProfile?.ToEntity()
        };
    }

    public static List<UserDto> ToDtos(this List<User> users)
    {
        if (users.Any())
        {
            return users.Select(ToDto).ToList();
        }

        return new List<UserDto>();
    }
    
    public static List<User> ToEntities(this List<UserDto> userDtos)
    {
        if (userDtos.Any())
        {
            return userDtos.Select(ToEntity).ToList();
        }

        return new List<User>();
    }
}