using System;
using ErrorOr;
using MediatR;

namespace MakeAdsApi.Application.Users.Commands.Common;

public record ConnectUserFromRetailDataCommand(
    Guid CompanyId,
    string PropertyId
) : IRequest<ErrorOr<Unit>>;