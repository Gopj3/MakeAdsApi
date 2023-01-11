using System;

namespace MakeAdsApi.Application.Users.Models;

public record UserProfileDto(
    Guid Id,
    string FirstName,
    string LastName,
    string? Title,
    string? Avatar,
    string? Phone
);