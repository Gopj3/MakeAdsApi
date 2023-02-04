using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using ErrorOr;
using MakeAdsApi.Application.BudgetItems.Shared.Models;
using MakeAdsApi.Application.Common.Abstractions.Repositories;
using MakeAdsApi.Application.Common.ViewModels;
using MediatR;

namespace MakeAdsApi.Application.BudgetItems.Admin.Queries.Lists;

public class PaginatedBudgetItemsQueryHandler: IRequestHandler<PaginatedBudgetItemsQuery, ErrorOr<BaseViewListModel<BudgetItemViewModel>>>
{
    private readonly IUnitOfWork _unitOfWork;

    public PaginatedBudgetItemsQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<ErrorOr<BaseViewListModel<BudgetItemViewModel>>> Handle(PaginatedBudgetItemsQuery request, CancellationToken cancellationToken)
    {
        var pagedList = await _unitOfWork.BudgetItemRepository.GetPaginatedByBudgetIdAsync(
            request.Page, request.PageSize, request.BudgetId, request.Search, cancellationToken);

        return new BaseViewListModel<BudgetItemViewModel>
        {
            Page = pagedList.CurrentPage,
            PageSize = pagedList.PageSize,
            HasNextPage = pagedList.HasNext,
            HasPreviousPage = pagedList.HasPrevious,
            TotalCount = pagedList.TotalCount,
            Items = pagedList.Select(BudgetItemViewModel.From)
        };
    }
}