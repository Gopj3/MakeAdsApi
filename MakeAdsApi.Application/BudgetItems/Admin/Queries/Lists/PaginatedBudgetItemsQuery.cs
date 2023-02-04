using System;
using ErrorOr;
using MakeAdsApi.Application.BudgetItems.Shared.Models;
using MakeAdsApi.Application.Common.ViewModels;
using MediatR;

namespace MakeAdsApi.Application.BudgetItems.Admin.Queries.Lists;

public record PaginatedBudgetItemsQuery(
    Guid BudgetId,
    int Page,
    int PageSize,
    string? Search
) : IRequest<ErrorOr<BaseViewListModel<BudgetItemViewModel>>>;