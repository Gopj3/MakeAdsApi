using ErrorOr;
using MakeAdsApi.Application.Common.ViewModels;
using MakeAdsApi.Application.Offices.Admin.Models;
using MediatR;

namespace MakeAdsApi.Application.Offices.Admin.Queries.List;

public record PaginatedOfficesQuery(
    int Page,
    int PageSize,
    string? Search
    ) : IRequest<ErrorOr<BaseViewListModel<OfficeViewModel>>>;
