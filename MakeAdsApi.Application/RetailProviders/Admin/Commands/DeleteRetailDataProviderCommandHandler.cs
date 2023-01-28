using System.Threading;
using System.Threading.Tasks;
using ErrorOr;
using MakeAdsApi.Application.Common.Abstractions.Repositories;
using MakeAdsApi.Domain.Errors;
using MediatR;

namespace MakeAdsApi.Application.RetailProviders.Admin.Commands;

public class DeleteRetailDataProviderCommandHandler: IRequestHandler<DeleteRetailDataProviderCommand, ErrorOr<Unit>>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteRetailDataProviderCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<ErrorOr<Unit>> Handle(DeleteRetailDataProviderCommand request, CancellationToken cancellationToken)
    {
        var retailProvider = await _unitOfWork.RetailDataProviderRepository.GetByIdAsync(request.Id, cancellationToken);

        if (retailProvider is null)
        {
            return DomainErrors.RetailDataProvider.NotFound;
        }
        
        _unitOfWork.RetailDataProviderRepository.Delete(retailProvider);
        await _unitOfWork.SaveChangesAsync();
        
        return Unit.Value;
    }
}