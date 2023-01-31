using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using ErrorOr;
using MakeAdsApi.Application.Common.Abstractions.Repositories;
using MakeAdsApi.Application.Offices.Admin.Models;
using MakeAdsApi.Domain.Entities.Offices;
using MakeAdsApi.Domain.Errors;
using MediatR;

namespace MakeAdsApi.Application.Offices.Admin.Commands;

public class CreateOfficeCommandHandler : IRequestHandler<CreateOfficeCommand, ErrorOr<OfficeViewModel>>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateOfficeCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<ErrorOr<OfficeViewModel>> Handle(CreateOfficeCommand request, CancellationToken cancellationToken)
    {
        List<Office> offices = await _unitOfWork.OfficeRepository
            .GetByExpressionAsync(x => x.ExternalId == request.ExternalId, cancellationToken);

        if (offices.Any())
        {
            return DomainErrors.Office.DuplicateCompanyExternalId;
        }

        Office office = new Office(request.Title, request.ExternalId, request.CompanyId);
        await _unitOfWork.OfficeRepository.CreateAsync(office);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return OfficeViewModel.From(office);
    }
}