using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using ErrorOr;
using MakeAdsApi.Application.Common.Abstractions.Repositories;
using MakeAdsApi.Application.RetailProviders.Admin.Models;
using MediatR;

namespace MakeAdsApi.Application.RetailProviders.Admin.Queries.Lists;

public class GetAllProvidersQueryHandler: IRequestHandler<GetAllProvidersQuery, ErrorOr<List<RetailDataProviderViewModel>>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllProvidersQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<ErrorOr<List<RetailDataProviderViewModel>>> Handle(GetAllProvidersQuery request, CancellationToken cancellationToken)
    {
        var result = await _unitOfWork.RetailDataProviderRepository.GetAllAsync(cancellationToken);

        return result.Select(RetailDataProviderViewModel.From).ToList();
    }
}