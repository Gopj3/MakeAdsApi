using System;

namespace MakeAdsApi.Application.Users.Models;

public record UserDto(Guid Id, string Email, UserProfileDto? UserProfile);