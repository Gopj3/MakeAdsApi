using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using ErrorOr;
using MakeAdsApi.Application.Common.Abstractions.Repositories;
using MakeAdsApi.Application.Users.Models;
using MakeAdsApi.Application.Users.Models.Mappers;

namespace MakeAdsApi.Application.Users.Queries.Lists;

public class GetPaginatedUserQueryHandler: IRequestHandler<GetPaginatedUserQuery, ErrorOr<List<UserDto>>>
{
    private IUnitOfWork _unitOfWork;
    
    public GetPaginatedUserQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    
    public async Task<ErrorOr<List<UserDto>>> Handle(GetPaginatedUserQuery request, CancellationToken cancellationToken)
    {
        var users = await _unitOfWork
            .UserRepository
            .GetEntitiesPaginated(request.Page, request.PageSize, cancellationToken);

        return users.ToDtos();
    }
}