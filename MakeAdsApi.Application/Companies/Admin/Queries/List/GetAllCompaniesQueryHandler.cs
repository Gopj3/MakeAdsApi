using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using ErrorOr;
using MakeAdsApi.Application.Common.Abstractions.Repositories;
using MakeAdsApi.Application.Companies.Admin.Models;
using MediatR;

namespace MakeAdsApi.Application.Companies.Admin.Queries.List;

public class GetAllCompaniesQueryHandler: IRequestHandler<GetAllCompaniesQuery, ErrorOr<List<CompanyViewModel>>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllCompaniesQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<ErrorOr<List<CompanyViewModel>>> Handle(GetAllCompaniesQuery request, CancellationToken cancellationToken)
    {
        var companies = await _unitOfWork.CompanyRepository.GetAllAsync(cancellationToken);

        return companies.Select(CompanyViewModel.From).ToList();
    }
}