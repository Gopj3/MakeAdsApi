using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using ErrorOr;
using MakeAdsApi.Application.Common.Abstractions.Repositories;
using MakeAdsApi.Application.Offices.Admin.Models;
using MakeAdsApi.Domain.Errors;
using MediatR;

namespace MakeAdsApi.Application.Offices.Admin.Commands;

public class UpdateOfficeCommandHandler : IRequestHandler<UpdateOfficeCommand, ErrorOr<OfficeViewModel>>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateOfficeCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<ErrorOr<OfficeViewModel>> Handle(UpdateOfficeCommand request, CancellationToken cancellationToken)
    {
        var office = await _unitOfWork.OfficeRepository.GetByIdAsync(request.Id, cancellationToken);

        if (office is null)
        {
            return DomainErrors.Office.NotFound;
        }

        var existedOffices = await _unitOfWork.OfficeRepository.GetByExpressionAsync(
            x => x.ExternalId == request.ExternalId && x.Id != request.Id, cancellationToken);

        if (existedOffices.Any())
        {
            return DomainErrors.Office.DuplicateCompanyExternalId;
        }
        
        office.Update(request.Title, request.ExternalId, request.CompanyId);
        _unitOfWork.OfficeRepository.Update(office);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return OfficeViewModel.From(office);
    }
}