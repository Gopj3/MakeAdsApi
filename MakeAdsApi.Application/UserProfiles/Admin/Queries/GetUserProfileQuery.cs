using System;
using ErrorOr;
using MakeAdsApi.Application.UserProfiles.Shared.Models;
using MediatR;

namespace MakeAdsApi.Application.UserProfiles.Admin.Queries;

public record GetUserProfileQuery(Guid UserId): IRequest<ErrorOr<UserProfileViewModel>>;
