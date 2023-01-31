using System;
using ErrorOr;
using MakeAdsApi.Application.Budgets.Admin.Models;
using MediatR;

namespace MakeAdsApi.Application.Budgets.Admin.Commands;

public record UpdateBudgetCommand(Guid Id, string Title, Guid CompanyId): IRequest<ErrorOr<BudgetViewModel>>;
