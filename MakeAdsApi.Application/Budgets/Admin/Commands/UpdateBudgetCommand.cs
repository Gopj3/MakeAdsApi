using System;
using ErrorOr;
using MakeAdsApi.Application.Budgets.Shared.Models;
using MakeAdsApi.Domain.Enums.Budgets;
using MediatR;

namespace MakeAdsApi.Application.Budgets.Admin.Commands;

public record UpdateBudgetCommand(
    Guid Id,
    string Title,
    BudgetType Type,
    Guid CompanyId
) : IRequest<ErrorOr<BudgetViewModel>>;