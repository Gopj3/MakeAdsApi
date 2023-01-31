using System.Threading;
using System.Threading.Tasks;
using ErrorOr;
using MakeAdsApi.Application.Common.Abstractions.Repositories;
using MakeAdsApi.Application.Offices.Admin.Models;
using MakeAdsApi.Domain.Errors;
using MediatR;

namespace MakeAdsApi.Application.Offices.Admin.Queries.Single;

public class GetOfficeByIdQueryHandler: IRequestHandler<GetOfficeByIdQuery, ErrorOr<OfficeViewModel>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetOfficeByIdQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<ErrorOr<OfficeViewModel>> Handle(GetOfficeByIdQuery request, CancellationToken cancellationToken)
    {
        var office = await _unitOfWork.OfficeRepository.GetWithCompanyByIdAsync(request.Id, cancellationToken);

        if (office is null)
        {
            return DomainErrors.Office.NotFound;
        }

        return OfficeViewModel.From(office);
    }
}