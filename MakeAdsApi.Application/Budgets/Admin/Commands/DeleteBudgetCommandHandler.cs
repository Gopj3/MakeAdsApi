using System.Threading;
using System.Threading.Tasks;
using ErrorOr;
using MakeAdsApi.Application.Common.Abstractions.Repositories;
using MakeAdsApi.Domain.Errors;
using MediatR;

namespace MakeAdsApi.Application.Budgets.Admin.Commands;

public class DeleteBudgetCommandHandler: IRequestHandler<DeleteBudgetCommand, ErrorOr<Unit>>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteBudgetCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<ErrorOr<Unit>> Handle(DeleteBudgetCommand request, CancellationToken cancellationToken)
    {
        var budget = await _unitOfWork.BudgetRepository.GetByIdAsync(request.Id, cancellationToken);
        if (budget is null)
        {
            return DomainErrors.Budget.NotFound;
        }
        
        _unitOfWork.BudgetRepository.Delete(budget);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}