using System.Threading;
using System.Threading.Tasks;
using ErrorOr;
using MakeAdsApi.Application.BudgetItems.Shared.Models;
using MakeAdsApi.Application.Common.Abstractions.Repositories;
using MakeAdsApi.Domain.Errors;
using MediatR;

namespace MakeAdsApi.Application.BudgetItems.Admin.Queries.Single;

public class GetByIdBudgetItemQueryHandler: IRequestHandler<GetByIdBudgetItemQuery, ErrorOr<BudgetItemViewModel>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetByIdBudgetItemQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<ErrorOr<BudgetItemViewModel>> Handle(GetByIdBudgetItemQuery request, CancellationToken cancellationToken)
    {
        var item = await _unitOfWork.BudgetItemRepository.GetByIdAsync(request.Id, cancellationToken);

        if (item is null)
        {
            return DomainErrors.BudgetItem.NotFound;
        }

        return BudgetItemViewModel.From(item);
    }
}