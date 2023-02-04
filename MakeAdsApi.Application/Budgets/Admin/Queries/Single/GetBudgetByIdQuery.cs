using System;
using ErrorOr;
using MakeAdsApi.Application.Budgets.Shared.Models;
using MediatR;

namespace MakeAdsApi.Application.Budgets.Admin.Queries.Single;

public record GetBudgetByIdQuery(Guid Id) : IRequest<ErrorOr<BudgetViewModel>>;
