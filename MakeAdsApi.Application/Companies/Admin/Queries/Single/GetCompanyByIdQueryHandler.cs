using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using ErrorOr;
using MakeAdsApi.Application.Common.Abstractions.Repositories;
using MakeAdsApi.Application.Companies.Admin.Models;
using MakeAdsApi.Domain.Errors;
using MediatR;

namespace MakeAdsApi.Application.Companies.Admin.Queries.Single;

public class GetCompanyByIdQueryHandler : IRequestHandler<GetCompanyByIdQuery, ErrorOr<CompanyViewModel>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetCompanyByIdQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<ErrorOr<CompanyViewModel>> Handle(
        GetCompanyByIdQuery request,
        CancellationToken cancellationToken
    )
    {
        var company = await _unitOfWork.CompanyRepository.GetCompanyWithProviderByIdAsync(request.Id, cancellationToken);

        if (company == null)
        {
            return DomainErrors.Company.NotFound;
        }

        return _mapper.Map<CompanyViewModel>(company);
    }
}