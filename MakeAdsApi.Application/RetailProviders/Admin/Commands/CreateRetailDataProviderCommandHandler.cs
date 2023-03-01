using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using ErrorOr;
using MakeAdsApi.Application.Common.Abstractions.Repositories;
using MakeAdsApi.Application.RetailProviders.Admin.Models;
using MakeAdsApi.Domain.Entities.RetailDataProviders;
using MediatR;

namespace MakeAdsApi.Application.RetailProviders.Admin.Commands;

public class CreateRetailDataProviderCommandHandler :
    IRequestHandler<CreateRetailDataProviderCommand, ErrorOr<RetailDataProviderViewModel>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public CreateRetailDataProviderCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<ErrorOr<RetailDataProviderViewModel>> Handle(
        CreateRetailDataProviderCommand request,
        CancellationToken cancellationToken
    )
    {
        var retailProvider = new RetailDataProvider
        {
            Id = Guid.NewGuid(),
            Title = request.Title,
            FetchPropertyDataUrl = request.FetchPropertyDataUrl,
            UpdatePropertyDataUrl = request.UpdatePropertyDataUrl,
            FetchUserDataUrl = request.FetchUserDataUrl,
            UpdateUserDataUrl = request.UpdateUserDataUrl
        };
        await _unitOfWork.RetailDataProviderRepository.CreateAsync(retailProvider, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return _mapper.Map<RetailDataProviderViewModel>(retailProvider);
    }
}