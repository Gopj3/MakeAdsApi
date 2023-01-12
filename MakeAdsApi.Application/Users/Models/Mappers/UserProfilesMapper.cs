using System.Collections.Generic;
using System.Linq;
using MakeAdsApi.Domain.Entities.Users;

namespace MakeAdsApi.Application.Users.Models.Mappers;

public static class UserProfilesMapper
{
    public static UserProfileDto ToDto(this UserProfile userProfile)
    {
        return new UserProfileDto
        {
            Id = userProfile.Id,
            FirstName = userProfile.FirstName,
            LastName = userProfile.LastName,
            Title = userProfile.Title,
            Avatar = userProfile.Avatar,
            Phone = userProfile.Phone,
            CreatedAt = userProfile.CreatedAt,
            UpdatedAt = userProfile.UpdatedAt,
        };
    }

    public static UserProfile ToEntity(this UserProfileDto userProfileDto)
    {
        return new UserProfile
        {
            FirstName = userProfileDto.FirstName,
            LastName = userProfileDto.LastName,
            Title = userProfileDto.Title,
            Avatar = userProfileDto.Avatar,
            Phone = userProfileDto.Phone
        };
    }

    public static UserProfile ToEntity(this UserProfileDto userProfileDto, User user)
    {
        var dto = userProfileDto.ToEntity();
        dto.User = user;

        return dto;
    }

    public static List<UserProfileDto> ToDtos(this List<UserProfile> userProfiles)
    {
        if (userProfiles.Any())
        {
            return userProfiles.Select(ToDto).ToList();
        }

        return new List<UserProfileDto>();
    }

    public static List<UserProfile> ToEntities(this List<UserProfileDto> userProfilesDto)
    {
        if (userProfilesDto.Any())
        {
            return userProfilesDto.Select(ToEntity).ToList();
        }

        return new List<UserProfile>();
    }

    public static List<UserProfile> ToEntities(this List<UserProfileDto> userProfilesDto, User user)
    {
        if (userProfilesDto.Any())
        {
            return userProfilesDto.Select(x => x.ToEntity(user)).ToList();
        }

        return new List<UserProfile>();
    }
}