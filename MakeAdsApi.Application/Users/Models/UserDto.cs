using MakeAdsApi.Application.Common.Dtos;

namespace MakeAdsApi.Application.Users.Models;

public record UserDto: BaseDto
{
     public string Email { get; set; }
     public UserProfileDto? UserProfile { get; set; }
};