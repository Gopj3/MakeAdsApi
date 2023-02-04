using System.Threading;
using System.Threading.Tasks;
using ErrorOr;
using MakeAdsApi.Application.Budgets.Shared.Models;
using MakeAdsApi.Application.Common.Abstractions.Repositories;
using MakeAdsApi.Domain.Errors;
using MediatR;

namespace MakeAdsApi.Application.Budgets.Admin.Queries.Single;

public class GetBudgetByIdQueryHandler: IRequestHandler<GetBudgetByIdQuery, ErrorOr<BudgetViewModel>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetBudgetByIdQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<ErrorOr<BudgetViewModel>> Handle(GetBudgetByIdQuery request, CancellationToken cancellationToken)
    {
        var budget = await _unitOfWork.BudgetRepository.GetByIdWithCompanyAsync(request.Id, cancellationToken);
        if (budget is null)
        {
            return DomainErrors.Budget.NotFound;
        }

        return BudgetViewModel.From(budget);
    }
}