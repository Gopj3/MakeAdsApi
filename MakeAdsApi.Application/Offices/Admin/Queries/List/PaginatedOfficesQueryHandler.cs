using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using ErrorOr;
using MakeAdsApi.Application.Common.Abstractions.Repositories;
using MakeAdsApi.Application.Common.ViewModels;
using MakeAdsApi.Application.Offices.Admin.Models;
using MediatR;

namespace MakeAdsApi.Application.Offices.Admin.Queries.List;

public class PaginatedOfficesQueryHandler: IRequestHandler<PaginatedOfficesQuery, ErrorOr<BaseViewListModel<OfficeViewModel>>>
{
    private readonly IUnitOfWork _unitOfWork;

    public PaginatedOfficesQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<ErrorOr<BaseViewListModel<OfficeViewModel>>> Handle(PaginatedOfficesQuery request, CancellationToken cancellationToken)
    {
        var offices = await _unitOfWork.OfficeRepository.GetEntitiesPaginatedAsync(
            request.Page,
            request.PageSize,
            !String.IsNullOrWhiteSpace(request.Search) 
                ? x => x.Title.Contains(request.Search.Trim()) 
                : null,
            cancellationToken
        );

        return new BaseViewListModel<OfficeViewModel>
        {
            Items = offices.Select(OfficeViewModel.From),
            Page = offices.CurrentPage,
            PageSize = offices.PageSize,
            HasNextPage = offices.HasNext,
            TotalCount = offices.TotalCount,
            HasPreviousPage = offices.HasPrevious
        };
    }
}