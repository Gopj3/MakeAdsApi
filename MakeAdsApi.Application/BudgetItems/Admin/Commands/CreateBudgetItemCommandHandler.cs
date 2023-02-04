using System.Threading;
using System.Threading.Tasks;
using ErrorOr;
using MakeAdsApi.Application.BudgetItems.Shared.Models;
using MakeAdsApi.Application.Budgets.Shared.Models;
using MakeAdsApi.Application.Common.Abstractions.Repositories;
using MakeAdsApi.Domain.Entities.Budgets;
using MakeAdsApi.Domain.Errors;
using MediatR;

namespace MakeAdsApi.Application.BudgetItems.Admin.Commands;

public class CreateBudgetItemCommandHandler : IRequestHandler<CreateBudgetItemCommand, ErrorOr<BudgetItemViewModel>>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateBudgetItemCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<ErrorOr<BudgetItemViewModel>> Handle(CreateBudgetItemCommand request,
        CancellationToken cancellationToken)
    {
        var budget = await _unitOfWork.BudgetRepository.GetByIdAsync(request.BudgetId, cancellationToken);
        if (budget is null)
        {
            return DomainErrors.Budget.NotFound;
        }

        var countByType =
            await _unitOfWork.BudgetItemRepository.CountBudgetItemsOfBudgetByTypeAsync(budget.Id, request.Type,
                cancellationToken);

        if (countByType > 0)
        {
            return DomainErrors.BudgetItem.DuplicateBudgetItemByType;
        }

        var budgetItem = new BudgetItem(budget.Id, request.Value, request.Type);
        await _unitOfWork.BudgetItemRepository.CreateAsync(budgetItem, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return BudgetItemViewModel.From(budgetItem);
    }
}