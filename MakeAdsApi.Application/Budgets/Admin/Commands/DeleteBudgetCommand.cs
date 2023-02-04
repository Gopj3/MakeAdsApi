using System;
using ErrorOr;
using MediatR;

namespace MakeAdsApi.Application.Budgets.Admin.Commands;

public record DeleteBudgetCommand(Guid Id): IRequest<ErrorOr<Unit>>;