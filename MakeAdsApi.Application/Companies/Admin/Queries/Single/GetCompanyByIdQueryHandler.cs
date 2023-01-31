using System.Threading;
using System.Threading.Tasks;
using ErrorOr;
using MakeAdsApi.Application.Common.Abstractions.Repositories;
using MakeAdsApi.Application.Companies.Admin.Models;
using MakeAdsApi.Domain.Errors;
using MediatR;

namespace MakeAdsApi.Application.Companies.Admin.Queries.Single;

public class GetCompanyByIdQueryHandler : IRequestHandler<GetCompanyByIdQuery, ErrorOr<CompanyViewModel>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetCompanyByIdQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<ErrorOr<CompanyViewModel>> Handle(
        GetCompanyByIdQuery request,
        CancellationToken cancellationToken
    )
    {
        var company = await _unitOfWork.CompanyRepository.GetCompanyByIdAsync(request.Id, cancellationToken);

        if (company == null)
        {
            return DomainErrors.Company.NotFound;
        }

        return CompanyViewModel.From(company);
    }
}