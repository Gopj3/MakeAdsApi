using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using ErrorOr;
using MakeAdsApi.Application.Common.Abstractions.Repositories;
using MakeAdsApi.Application.Common.ViewModels;
using MakeAdsApi.Application.Users.Models.Responses;

namespace MakeAdsApi.Application.Users.Queries.Lists;

public class
    GetPaginatedUserQueryHandler : IRequestHandler<GetPaginatedUserQuery, ErrorOr<BaseViewListModel<UserViewModel>>>
{
    private IUnitOfWork _unitOfWork;

    public GetPaginatedUserQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<ErrorOr<BaseViewListModel<UserViewModel>>> Handle(GetPaginatedUserQuery request,
        CancellationToken cancellationToken)
    {
        var users = await _unitOfWork
            .UserRepository
            .GetEntitiesPaginatedAsync(request.Page, request.PageSize, cancellationToken);

        return new BaseViewListModel<UserViewModel>(
            users.Select(UserViewModel.From),
            users.TotalCount,
            users.CurrentPage,
            users.PageSize,
            users.HasNext,
            users.HasPrevious
        );
    }
}