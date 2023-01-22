using System.Threading;
using System.Threading.Tasks;
using ErrorOr;
using MakeAdsApi.Application.Common.Abstractions.Repositories;
using MakeAdsApi.Application.Users.Models.Responses;
using MakeAdsApi.Domain.Errors;
using MediatR;

namespace MakeAdsApi.Application.Users.Queries.Single;

public class GetSingleUserByIdQueryHandler: IRequestHandler<GetSingleUserByIdQuery, ErrorOr<UserViewModel>>
{
    private readonly IUnitOfWork _unitOfWork;
    
    public GetSingleUserByIdQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    
    public async Task<ErrorOr<UserViewModel>> Handle(GetSingleUserByIdQuery request, CancellationToken cancellationToken)
    {
        var user = await _unitOfWork
            .UserRepository.
            GetByExpressionWithRolesAsync(x => x.Id == request.Id, cancellationToken);

        if (user is null)
        {
            return DomainErrors.User.NotFound;
        }

        return UserViewModel.From(user);
    }
}