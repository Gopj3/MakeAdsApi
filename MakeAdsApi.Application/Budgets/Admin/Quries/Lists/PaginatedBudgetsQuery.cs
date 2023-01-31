using ErrorOr;
using MakeAdsApi.Application.Budgets.Admin.Models;
using MakeAdsApi.Application.Common.ViewModels;
using MediatR;

namespace MakeAdsApi.Application.Budgets.Admin.Quries.Lists;

public record PaginatedBudgetsQuery(
    int Page,
    int PageSize,
    string? Search
) : IRequest<ErrorOr<BaseViewListModel<BudgetViewModel>>>;