using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using ErrorOr;
using MakeAdsApi.Application.Common.Abstractions.Repositories;
using MakeAdsApi.Application.Common.Abstractions.Services.RetailDataProviders;
using MakeAdsApi.Application.Exceptions;
using MakeAdsApi.Application.RetailProviders.Common.Models;
using MakeAdsApi.Domain.Errors;
using MediatR;

namespace MakeAdsApi.Application.RetailProviders.User.Queries;

public class
    GetRetailDataForPropertyQueryHandler : IRequestHandler<GetRetailDataForPropertyQuery,
        ErrorOr<RetailDataApiResponseViewModel>>
{
    private readonly IRetailDataProviderHttpService _retailDataProviderHttpService;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetRetailDataForPropertyQueryHandler(
        IRetailDataProviderHttpService retailDataProviderHttpService,
        IUnitOfWork unitOfWork,
        IMapper mapper
    )
    {
        _retailDataProviderHttpService = retailDataProviderHttpService;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<ErrorOr<RetailDataApiResponseViewModel>> Handle(
        GetRetailDataForPropertyQuery request,
        CancellationToken cancellationToken
    )
    {
        var company = await _unitOfWork.CompanyRepository.GetCompanyWithRetailProviderByUserIdAsync(
            request.LoggedInUserId,
            cancellationToken
        );

        if (company is null)
            return DomainErrors.Company.NotFound;

        var data = await _retailDataProviderHttpService.GetRetailPropertyDataAsync(
            company.RetailDataProvider.FetchPropertyDataUrl!,
            company.ExternalId,
            request.PropertyId,
            cancellationToken
        );

        if (data is null)
            throw new RetailDataProviderException("No response from retail data provider");

        return _mapper.Map<RetailDataApiResponseViewModel>(data);
    }
}