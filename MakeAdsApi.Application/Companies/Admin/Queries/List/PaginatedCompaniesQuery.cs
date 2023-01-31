using ErrorOr;
using MakeAdsApi.Application.Common.ViewModels;
using MakeAdsApi.Application.Companies.Admin.Models;
using MediatR;

namespace MakeAdsApi.Application.Companies.Admin.Queries.List;

public record PaginatedCompaniesQuery(
    int Page,
    int PageSize,
    string? Search
) : IRequest<ErrorOr<BaseViewListModel<CompanyViewModel>>>;
