using System;
using ErrorOr;
using MakeAdsApi.Application.Users.Models.Responses;
using MediatR;

namespace MakeAdsApi.Application.Users.Queries.Admin.Single;

public record GetSingleUserByIdQuery(Guid Id) : IRequest<ErrorOr<UserViewModel>>;
