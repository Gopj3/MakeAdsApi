using System.Collections.Generic;
using MediatR;
using ErrorOr;
using MakeAdsApi.Application.Common.ViewModels;
using MakeAdsApi.Application.Users.Models.Responses;

namespace MakeAdsApi.Application.Users.Queries.Lists;

public record GetPaginatedUserQuery(int Page, int PageSize) : IRequest<ErrorOr<BaseViewListModel<UserViewModel>>>;