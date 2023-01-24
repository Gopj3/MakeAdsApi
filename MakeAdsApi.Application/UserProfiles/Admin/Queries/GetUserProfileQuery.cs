using System;
using ErrorOr;
using MakeAdsApi.Application.UserProfiles.Admin.Models;
using MediatR;

namespace MakeAdsApi.Application.UserProfiles.Admin.Queries;

public record GetUserProfileQuery(Guid UserId): IRequest<ErrorOr<UserProfileViewModel>>;
