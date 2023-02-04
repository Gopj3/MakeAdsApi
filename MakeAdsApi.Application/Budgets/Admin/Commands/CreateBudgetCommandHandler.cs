using System.Threading;
using System.Threading.Tasks;
using ErrorOr;
using MakeAdsApi.Application.Budgets.Shared.Models;
using MakeAdsApi.Application.Common.Abstractions.Repositories;
using MakeAdsApi.Domain.Entities.Budgets;
using MakeAdsApi.Domain.Enums.Budgets;
using MakeAdsApi.Domain.Errors;
using MediatR;

namespace MakeAdsApi.Application.Budgets.Admin.Commands;

public class CreateBudgetCommandHandler: IRequestHandler<CreateBudgetCommand, ErrorOr<BudgetViewModel>>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateBudgetCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<ErrorOr<BudgetViewModel>> Handle(CreateBudgetCommand request, CancellationToken cancellationToken)
    {
        if (BudgetType.Automatic.Equals(request.Type) || BudgetType.AfterSold.Equals(request.Type))
        {
            var existedBudgets = await _unitOfWork.BudgetRepository.CountBudgetsByBudgetTypeAndCompanyIdAsync(
                request.CompanyId, request.Type, cancellationToken);

            if (existedBudgets > 0)
            {
                return DomainErrors.Budget.DuplicateBudgetByType;
            }
        }
        
        var budget = new Budget(request.CompanyId, request.Title, request.Type);
        await _unitOfWork.BudgetRepository.CreateAsync(budget, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return BudgetViewModel.From(budget);
    }
}