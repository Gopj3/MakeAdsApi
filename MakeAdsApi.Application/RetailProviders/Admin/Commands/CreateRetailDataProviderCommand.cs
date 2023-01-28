using MakeAdsApi.Application.RetailProviders.Admin.Models;
using MediatR;
using ErrorOr;

namespace MakeAdsApi.Application.RetailProviders.Admin.Commands;

public record CreateRetailDataProviderCommand(
    string Title,
    string? FetchPropertyDataUrl,
    string? UpdatePropertyDataUrl,
    string? FetchUserDataUrl,
    string? UpdateUserDataUrl
) : IRequest<ErrorOr<RetailDataProviderViewModel>>;