using System;
using ErrorOr;
using MediatR;

namespace MakeAdsApi.Application.RetailProviders.Admin.Commands;

public record UpdateRetailDataProviderCommand(
    Guid Id,
    string Title,
    string? FetchPropertyDataUrl,
    string? UpdatePropertyDataUrl,
    string? FetchUserDataUrl,
    string? UpdateUserDataUrl
): IRequest<ErrorOr<Unit>>;