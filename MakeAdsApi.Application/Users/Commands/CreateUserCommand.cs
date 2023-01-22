using System;
using System.Collections.Generic;
using MediatR;
using Microsoft.AspNetCore.Http;
using ErrorOr;
using MakeAdsApi.Application.Users.Models.Responses;

namespace MakeAdsApi.Application.Users.Commands;

public record CreateUserCommand(
    string Email,
    List<Guid> RoleIds
) : IRequest<ErrorOr<UserViewModel>>;