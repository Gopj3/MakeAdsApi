using System.Threading;
using System.Threading.Tasks;
using ErrorOr;
using MakeAdsApi.Application.BudgetItems.Shared.Models;
using MakeAdsApi.Application.Common.Abstractions.Repositories;
using MakeAdsApi.Domain.Errors;
using MediatR;

namespace MakeAdsApi.Application.BudgetItems.Admin.Commands;

public class UpdateBudgetItemCommandHandler: IRequestHandler<UpdateBudgetItemCommand, ErrorOr<BudgetItemViewModel>>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateBudgetItemCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<ErrorOr<BudgetItemViewModel>> Handle(UpdateBudgetItemCommand request, CancellationToken cancellationToken)
    {
        var budgetItem = await _unitOfWork.BudgetItemRepository.GetByIdAsync(request.BudgetIemId, cancellationToken);

        if (budgetItem is null)
        {
            return DomainErrors.BudgetItem.NotFound;
        }
        
        budgetItem.Update(request.Value, request.Type);
        _unitOfWork.BudgetItemRepository.Update(budgetItem);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return BudgetItemViewModel.From(budgetItem);
    }
}