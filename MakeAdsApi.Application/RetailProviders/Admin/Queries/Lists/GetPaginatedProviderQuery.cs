using ErrorOr;
using MakeAdsApi.Application.Common.ViewModels;
using MakeAdsApi.Application.RetailProviders.Admin.Models;
using MediatR;

namespace MakeAdsApi.Application.RetailProviders.Admin.Queries.Lists;

public record GetPaginatedProviderQuery(
    int Page,
    int PageSize,
    string? Search = null
) : IRequest<ErrorOr<BaseViewListModel<RetailDataProviderViewModel>>>;