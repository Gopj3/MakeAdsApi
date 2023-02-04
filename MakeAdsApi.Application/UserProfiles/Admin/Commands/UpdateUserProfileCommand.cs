using System;
using ErrorOr;
using MakeAdsApi.Application.UserProfiles.Shared.Models;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace MakeAdsApi.Application.UserProfiles.Admin.Commands;

public record UpdateUserProfileCommand(
    Guid UserId,
    string FirstName,
    string LastName,
    string? Title,
    string? Phone,
    IFormFile? Avatar
) : IRequest<ErrorOr<UserProfileViewModel>>;