using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using ErrorOr;
using MakeAdsApi.Application.Common.Abstractions.Repositories;
using MakeAdsApi.Application.Companies.Admin.Models;
using MakeAdsApi.Domain.Entities.Companies;
using MakeAdsApi.Domain.Errors;
using MediatR;

namespace MakeAdsApi.Application.Companies.Admin.Commands;

public class CreateCompanyCommandHandler: IRequestHandler<CreateCompanyCommand, ErrorOr<CompanyViewModel>>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateCompanyCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<ErrorOr<CompanyViewModel>> Handle(CreateCompanyCommand request, CancellationToken cancellationToken)
    {
        var existedCompany = await _unitOfWork.CompanyRepository.GetByExpressionAsync(
            x => x.ExternalId == request.ExternalId, cancellationToken);

        if (existedCompany.Any())
        {
            return DomainErrors.Company.DuplicateCompanyExternalId;
        }
        
        var retailDataProvider = await _unitOfWork.RetailDataProviderRepository.GetByIdAsync(
            request.RetailDataProviderId, cancellationToken);

        if (retailDataProvider is null)
        {
            return DomainErrors.RetailDataProvider.NotFound;
        }

        var company = new Company(request.Title, request.ExternalId, retailDataProvider.Id);
        await _unitOfWork.CompanyRepository.CreateAsync(company, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return CompanyViewModel.From(company);
    }
}