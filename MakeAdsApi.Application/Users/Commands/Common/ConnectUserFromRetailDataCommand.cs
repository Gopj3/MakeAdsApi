using System;
using ErrorOr;
using MakeAdsApi.Application.Authentication.Models;
using MakeAdsApi.Domain.Entities.Users;
using MediatR;

namespace MakeAdsApi.Application.Users.Commands.Common;

public record ConnectUserFromRetailDataCommand(
    Guid CompanyId,
    string PropertyId
) : IRequest<ErrorOr<AuthenticationResult>>;