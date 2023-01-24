using System;
using ErrorOr;
using MakeAdsApi.Application.UserProfiles.Admin.Models;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace MakeAdsApi.Application.UserProfiles.Admin.Commands;

public record CreateUserProfileCommand(
    Guid UserId,
    string FirstName,
    string LastName,
    string? Title,
    string? Phone,
    IFormFile? Avatar
) : IRequest<ErrorOr<UserProfileViewModel>>;