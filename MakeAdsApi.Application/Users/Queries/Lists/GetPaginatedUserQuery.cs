using System.Collections.Generic;
using MakeAdsApi.Application.Users.Models;
using MediatR;
using ErrorOr;

namespace MakeAdsApi.Application.Users.Queries.Lists;

public record GetPaginatedUserQuery(int Page, int PageSize) : IRequest<ErrorOr<List<UserDto>>>;