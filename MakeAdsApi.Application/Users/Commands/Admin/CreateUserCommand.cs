using System;
using System.Collections.Generic;
using ErrorOr;
using MakeAdsApi.Application.Users.Models.Responses;
using MediatR;

namespace MakeAdsApi.Application.Users.Commands.Admin;

public record CreateUserCommand(
    string Email,
    List<Guid> RoleIds
) : IRequest<ErrorOr<UserViewModel>>;