using System.Threading;
using System.Threading.Tasks;
using ErrorOr;
using MakeAdsApi.Application.Budgets.Shared.Models;
using MakeAdsApi.Application.Common.Abstractions.Repositories;
using MakeAdsApi.Domain.Enums.Budgets;
using MakeAdsApi.Domain.Errors;
using MediatR;

namespace MakeAdsApi.Application.Budgets.Admin.Commands;

public class UpdateBudgetCommandHandler: IRequestHandler<UpdateBudgetCommand, ErrorOr<BudgetViewModel>>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateBudgetCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<ErrorOr<BudgetViewModel>> Handle(UpdateBudgetCommand request, CancellationToken cancellationToken)
    {
        var budget = await _unitOfWork.BudgetRepository.GetByIdAsync(request.Id, cancellationToken);

        if (budget is null)
        {
            return DomainErrors.Budget.NotFound;
        }
        
        if (BudgetType.Automatic.Equals(request.Type) || BudgetType.AfterSold.Equals(request.Type))
        {
            var existedBudgets = await _unitOfWork.BudgetRepository.CountBudgetsByBudgetTypeAndCompanyIdAsync(
                request.CompanyId, request.Type, cancellationToken);

            if (existedBudgets > 0)
            {
                return DomainErrors.Budget.DuplicateBudgetByType;
            }
        }
        
        budget.Update(request.Title, request.CompanyId, request.Type);
        _unitOfWork.BudgetRepository.Update(budget);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return BudgetViewModel.From(budget);
    }
}