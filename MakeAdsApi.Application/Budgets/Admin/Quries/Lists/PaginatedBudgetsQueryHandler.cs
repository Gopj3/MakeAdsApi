using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using ErrorOr;
using MakeAdsApi.Application.Budgets.Admin.Models;
using MakeAdsApi.Application.Common.Abstractions.Repositories;
using MakeAdsApi.Application.Common.ViewModels;
using MediatR;

namespace MakeAdsApi.Application.Budgets.Admin.Quries.Lists;

public class PaginatedBudgetsQueryHandler: IRequestHandler<PaginatedBudgetsQuery, ErrorOr<BaseViewListModel<BudgetViewModel>>>
{
    private readonly IUnitOfWork _unitOfWork;

    public PaginatedBudgetsQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<ErrorOr<BaseViewListModel<BudgetViewModel>>> Handle(PaginatedBudgetsQuery request, CancellationToken cancellationToken)
    {
        var res = await _unitOfWork.BudgetRepository.GetPaginatedWithCompanyAsync(
            request.Page, request.PageSize, request.Search, cancellationToken);

        return new BaseViewListModel<BudgetViewModel>
        {
            Items = res.Select(BudgetViewModel.From),
            Page = res.CurrentPage,
            PageSize = res.PageSize,
            TotalCount = res.TotalCount,
            HasNextPage = res.HasNext,
            HasPreviousPage = res.HasPrevious
        };
    }
}