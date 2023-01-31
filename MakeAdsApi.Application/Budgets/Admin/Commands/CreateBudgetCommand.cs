using System;
using ErrorOr;
using MakeAdsApi.Application.Budgets.Admin.Models;
using MediatR;

namespace MakeAdsApi.Application.Budgets.Admin.Commands;

public record CreateBudgetCommand(
    string Title,
    Guid CompanyId
) : IRequest<ErrorOr<BudgetViewModel>>;