using System;
using ErrorOr;
using MediatR;

namespace MakeAdsApi.Application.RetailProviders.Admin.Commands;

public record DeleteRetailDataProviderCommand(Guid Id) : IRequest<ErrorOr<Unit>>;
