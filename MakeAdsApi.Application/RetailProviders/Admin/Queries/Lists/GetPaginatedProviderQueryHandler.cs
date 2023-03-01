using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using ErrorOr;
using MakeAdsApi.Application.Common.Abstractions.Repositories;
using MakeAdsApi.Application.Common.ViewModels;
using MakeAdsApi.Application.RetailProviders.Admin.Models;
using MakeAdsApi.Domain.Entities.RetailDataProviders;
using MediatR;

namespace MakeAdsApi.Application.RetailProviders.Admin.Queries.Lists;

public class GetPaginatedProviderQueryHandler
    : IRequestHandler<GetPaginatedProviderQuery, ErrorOr<BaseViewListModel<RetailDataProviderViewModel>>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetPaginatedProviderQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<ErrorOr<BaseViewListModel<RetailDataProviderViewModel>>> Handle(
        GetPaginatedProviderQuery request,
        CancellationToken cancellationToken
    )
    {
        Expression<Func<RetailDataProvider, bool>>? filter = null;

        if (!String.IsNullOrWhiteSpace(request.Search))
        {
            filter = provider => provider.Title.Contains(request.Search);
        }

        PagedList<RetailDataProvider> retailDataProviders = await _unitOfWork.RetailDataProviderRepository
            .GetEntitiesPaginatedAsync(request.Page, request.PageSize, filter, cancellationToken);

        return new BaseViewListModel<RetailDataProviderViewModel>
        {
            Items = _mapper.Map<List<RetailDataProviderViewModel>>(retailDataProviders),
            TotalCount = retailDataProviders.TotalCount,
            Page = retailDataProviders.CurrentPage,
            PageSize = retailDataProviders.PageSize,
            HasNextPage = retailDataProviders.HasNext,
            HasPreviousPage = retailDataProviders.HasPrevious
        };
    }
}