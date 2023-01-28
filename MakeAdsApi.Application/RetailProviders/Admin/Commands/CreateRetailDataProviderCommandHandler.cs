using System;
using System.Threading;
using System.Threading.Tasks;
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

    public CreateRetailDataProviderCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<ErrorOr<RetailDataProviderViewModel>> Handle(
        CreateRetailDataProviderCommand request,
        CancellationToken cancellationToken
    )
    {
        var retailProvider = new RetailDataProvider(
            Guid.NewGuid(),
            request.Title,
            request.FetchPropertyDataUrl,
            request.UpdatePropertyDataUrl,
            request.FetchUserDataUrl,
            request.UpdateUserDataUrl
        );
        await _unitOfWork.RetailDataProviderRepository.CreateAsync(retailProvider, cancellationToken);

        return RetailDataProviderViewModel.From(retailProvider);
    }
}