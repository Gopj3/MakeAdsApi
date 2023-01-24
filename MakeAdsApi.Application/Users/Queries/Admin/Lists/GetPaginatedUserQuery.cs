using ErrorOr;
using MakeAdsApi.Application.Common.ViewModels;
using MakeAdsApi.Application.Users.Models.Responses;
using MediatR;

namespace MakeAdsApi.Application.Users.Queries.Admin.Lists;

public record GetPaginatedUserQuery(int Page, int PageSize) : IRequest<ErrorOr<BaseViewListModel<UserViewModel>>>;