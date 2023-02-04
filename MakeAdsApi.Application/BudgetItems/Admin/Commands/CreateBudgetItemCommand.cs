using System;
using ErrorOr;
using MakeAdsApi.Application.BudgetItems.Shared.Models;
using MakeAdsApi.Domain.Enums.Budgets;
using MediatR;

namespace MakeAdsApi.Application.BudgetItems.Admin.Commands;

public record CreateBudgetItemCommand(
    Guid BudgetId,
    decimal Value,
    BudgetItemType Type
) :  IRequest<ErrorOr<BudgetItemViewModel>>;