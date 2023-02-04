using System;
using ErrorOr;
using MakeAdsApi.Application.BudgetItems.Shared.Models;
using MakeAdsApi.Domain.Enums.Budgets;
using MediatR;

namespace MakeAdsApi.Application.BudgetItems.Admin.Commands;

public record UpdateBudgetItemCommand(
    Guid BudgetIemId,
    decimal Value,
    BudgetItemType Type
) :  IRequest<ErrorOr<BudgetItemViewModel>>;