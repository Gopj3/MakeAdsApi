using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using ErrorOr;
using MakeAdsApi.Application.Common.Abstractions.Repositories;
using MakeAdsApi.Application.Companies.Admin.Models;
using MakeAdsApi.Domain.Errors;
using MediatR;

namespace MakeAdsApi.Application.Companies.Admin.Commands;

public class UpdateCompanyCommandHandler : IRequestHandler<UpdateCompanyCommand, ErrorOr<CompanyViewModel>>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateCompanyCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<ErrorOr<CompanyViewModel>> Handle(UpdateCompanyCommand request,
        CancellationToken cancellationToken)
    {
        var company = await _unitOfWork.CompanyRepository.GetByIdAsync(request.Id, cancellationToken);

        if (company is null)
        {
            return DomainErrors.Company.NotFound;
        }

        var otherCompanies = await _unitOfWork.CompanyRepository.GetByExpressionAsync(
                x => x.Id != request.Id && x.ExternalId == request.ExternalId,
                cancellationToken
            );

        if (otherCompanies.Any())
        {
            return DomainErrors.Company.DuplicateCompanyExternalId;
        }

        var retailDataProvider = await _unitOfWork.RetailDataProviderRepository.GetByIdAsync(
            request.RetailDataProviderId,
            cancellationToken
        );

        if (retailDataProvider is null)
        {
            return DomainErrors.RetailDataProvider.NotFound;
        }

        company.Update(request.Title, request.ExternalId, retailDataProvider.Id);
        _unitOfWork.CompanyRepository.Update(company);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return CompanyViewModel.From(company);
    }
}