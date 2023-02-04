using System.Threading;
using System.Threading.Tasks;
using ErrorOr;
using MakeAdsApi.Application.Common.Abstractions.Repositories;
using MakeAdsApi.Domain.Errors;
using MediatR;

namespace MakeAdsApi.Application.BudgetItems.Admin.Commands;

public class DeleteBudgetItemCommandHandler: IRequestHandler<DeleteBudgetItemCommand, ErrorOr<Unit>>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteBudgetItemCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<ErrorOr<Unit>> Handle(DeleteBudgetItemCommand request, CancellationToken cancellationToken)
    {
        var item = await _unitOfWork.BudgetItemRepository.GetByIdAsync(request.BudgetItemId, cancellationToken);

        if (item is null)
        {
            return DomainErrors.BudgetItem.NotFound;
        }

        _unitOfWork.BudgetItemRepository.Delete(item);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}