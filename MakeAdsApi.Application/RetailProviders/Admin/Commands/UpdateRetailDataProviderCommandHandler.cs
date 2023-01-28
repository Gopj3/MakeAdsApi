using System.Threading;
using System.Threading.Tasks;
using ErrorOr;
using MakeAdsApi.Application.Common.Abstractions.Repositories;
using MakeAdsApi.Domain.Errors;
using MediatR;

namespace MakeAdsApi.Application.RetailProviders.Admin.Commands;

public class UpdateRetailDataProviderCommandHandler : IRequestHandler<UpdateRetailDataProviderCommand, ErrorOr<Unit>>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateRetailDataProviderCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<ErrorOr<Unit>> Handle(UpdateRetailDataProviderCommand request,
        CancellationToken cancellationToken)
    {
        var retailProvider = await _unitOfWork.RetailDataProviderRepository.GetByIdAsync(request.Id, cancellationToken);

        if (retailProvider is null)
        {
            return DomainErrors.RetailDataProvider.NotFound;
        }

        retailProvider.Update(
            request.Title,
            request.FetchPropertyDataUrl,
            request.UpdatePropertyDataUrl,
            request.FetchUserDataUrl,
            request.UpdateUserDataUrl
        );
        
        _unitOfWork.RetailDataProviderRepository.Update(retailProvider);
        await _unitOfWork.SaveChangesAsync();
        
        return Unit.Value;
    }
}