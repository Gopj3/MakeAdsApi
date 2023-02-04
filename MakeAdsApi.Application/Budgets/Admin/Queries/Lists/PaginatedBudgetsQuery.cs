using System;
using ErrorOr;
using MakeAdsApi.Application.Budgets.Shared.Models;
using MakeAdsApi.Application.Common.ViewModels;
using MediatR;

namespace MakeAdsApi.Application.Budgets.Admin.Queries.Lists;

public record PaginatedBudgetsQuery(
    Guid CompanyId,
    int Page,
    int PageSize,
    string? Search
) : IRequest<ErrorOr<BaseViewListModel<BudgetViewModel>>>;