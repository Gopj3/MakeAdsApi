using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using ErrorOr;
using MakeAdsApi.Application.Common.Abstractions.Repositories;
using MakeAdsApi.Application.RetailProviders.Admin.Models;
using MediatR;

namespace MakeAdsApi.Application.RetailProviders.Admin.Queries.Lists;

public class GetAllProvidersQueryHandler: IRequestHandler<GetAllProvidersQuery, ErrorOr<List<RetailDataProviderViewModel>>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetAllProvidersQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<ErrorOr<List<RetailDataProviderViewModel>>> Handle(GetAllProvidersQuery request, CancellationToken cancellationToken)
    {
        var result = await _unitOfWork.RetailDataProviderRepository.GetAllAsync(cancellationToken);

        return _mapper.Map<List<RetailDataProviderViewModel>>(result);
    }
}