using System.Threading;
using System.Threading.Tasks;
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

    public SingleRetailDataProviderQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
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

        return RetailDataProviderViewModel.From(provider);
    }
}