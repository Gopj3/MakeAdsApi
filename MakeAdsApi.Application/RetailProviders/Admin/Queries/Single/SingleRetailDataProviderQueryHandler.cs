using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using ErrorOr;
using MakeAdsApi.Application.Common.Abstractions.Repositories;
using MakeAdsApi.Application.RetailProviders.Admin.Models;
using MakeAdsApi.Domain.Errors;
using MediatR;

namespace MakeAdsApi.Application.RetailProviders.Admin.Queries.Single;

public class SingleRetailDataProviderQueryHandler
    : IRequestHandler<SingleRetailDataProviderByIdQuery, ErrorOr<RetailDataProviderViewModel>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public SingleRetailDataProviderQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<ErrorOr<RetailDataProviderViewModel>> Handle(
        SingleRetailDataProviderByIdQuery request,
        CancellationToken cancellationToken
    )
    {
        var provider = await _unitOfWork
            .RetailDataProviderRepository.GetByIdAsync(request.Id, cancellationToken);

        if (provider is null)
        {
            return DomainErrors.RetailDataProvider.NotFound;
        }

        return _mapper.Map<RetailDataProviderViewModel>(provider);
    }
}