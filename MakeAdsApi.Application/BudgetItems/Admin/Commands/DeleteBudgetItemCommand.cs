using System;
using ErrorOr;
using MediatR;

namespace MakeAdsApi.Application.BudgetItems.Admin.Commands;

public record DeleteBudgetItemCommand(Guid BudgetItemId) : IRequest<ErrorOr<Unit>>;
