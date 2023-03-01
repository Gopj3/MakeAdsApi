using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using ErrorOr;
using MakeAdsApi.Application.Common.Abstractions.Repositories;
using MakeAdsApi.Application.Common.ViewModels;
using MakeAdsApi.Application.Companies.Admin.Models;
using MakeAdsApi.Domain.Entities.Companies;
using MediatR;

namespace MakeAdsApi.Application.Companies.Admin.Queries.List;

public class PaginatedCompaniesQueryHandler: IRequestHandler<PaginatedCompaniesQuery, ErrorOr<BaseViewListModel<CompanyViewModel>>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public PaginatedCompaniesQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<ErrorOr<BaseViewListModel<CompanyViewModel>>> Handle(PaginatedCompaniesQuery request, CancellationToken cancellationToken)
    {
        var companies = await _unitOfWork
            .CompanyRepository.GetEntitiesPaginatedAsync(
                request.Page,
                request.PageSize,
                !String.IsNullOrWhiteSpace(request.Search) 
                    ? x => x.Title.Contains(request.Search.Trim())
                    : null,
                cancellationToken);

        return new BaseViewListModel<CompanyViewModel>
        {
            Items = _mapper.Map<List<CompanyViewModel>>(companies),
            TotalCount = companies.TotalCount,
            Page = companies.CurrentPage,
            PageSize = companies.PageSize,
            HasNextPage = companies.HasNext,
            HasPreviousPage = companies.HasPrevious
        };
    }
}