using System;
using MakeAdsApi.Application.Common.Dtos;

namespace MakeAdsApi.Application.Users.Models;

public record UserProfileDto: BaseDto
{
    public string FirstName { get; set; } = String.Empty;
    public string LastName { get; set; } = String.Empty;
    public string? Title { get; set; }
    public string? Avatar { get; set; }
    public string? Phone { get; set; }
}