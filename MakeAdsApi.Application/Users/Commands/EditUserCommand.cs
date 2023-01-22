using System;
using System.Collections.Generic;
using ErrorOr;
using MediatR;

namespace MakeAdsApi.Application.Users.Commands;

public record EditUserCommand( 
    Guid Id,
    string Email,
    List<Guid> RoleIds
) : IRequest<ErrorOr<object>>;
