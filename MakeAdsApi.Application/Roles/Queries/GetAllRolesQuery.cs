using System.Collections.Generic;
using Amazon.Runtime.Internal;
using ErrorOr;
using MakeAdsApi.Application.Roles.Models;
using MediatR;

namespace MakeAdsApi.Application.Roles.Queries;

public record GetAllRolesQuery: IRequest<ErrorOr<List<RoleViewModel>>>;