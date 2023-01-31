using System.Threading;
using System.Threading.Tasks;
using ErrorOr;
using MakeAdsApi.Application.Budgets.Admin.Models;
using MakeAdsApi.Application.Common.Abstractions.Repositories;
using MakeAdsApi.Domain.Entities.Budgets;
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
        var budget = new Budget(request.Title, request.CompanyId);
        await _unitOfWork.BudgetRepository.CreateAsync(budget, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return BudgetViewModel.From(budget);
    }
}