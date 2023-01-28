using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using ErrorOr;
using MakeAdsApi.Application.Common.Abstractions.Repositories;
using MakeAdsApi.Application.Common.ViewModels;
using MakeAdsApi.Application.Users.Models.Responses;
using MediatR;

namespace MakeAdsApi.Application.Users.Queries.Admin.Lists;

public class GetPaginatedUserQueryHandler 
    : IRequestHandler<GetPaginatedUserQuery, ErrorOr<BaseViewListModel<UserViewModel>>>
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
            .GetPaginatedWithSearchAsync(request.Page, request.PageSize, request.Search, cancellationToken);

        return new BaseViewListModel<UserViewModel>{
            Items = users.Select(UserViewModel.From),
            TotalCount = users.TotalCount,
            Page = users.CurrentPage,
            PageSize = users.PageSize,
            HasNextPage = users.HasNext,
            HasPreviousPage = users.HasPrevious
        };
    }
}