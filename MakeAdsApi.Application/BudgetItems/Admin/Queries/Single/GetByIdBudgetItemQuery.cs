using System;
using ErrorOr;
using MakeAdsApi.Application.BudgetItems.Shared.Models;
using MediatR;

namespace MakeAdsApi.Application.BudgetItems.Admin.Queries.Single;

public record GetByIdBudgetItemQuery(Guid Id) : IRequest<ErrorOr<BudgetItemViewModel>>;
