using System.Collections.Generic;
using ErrorOr;
using MakeAdsApi.Application.RetailProviders.Admin.Models;
using MediatR;

namespace MakeAdsApi.Application.RetailProviders.Admin.Queries.Lists;

public record GetAllProvidersQuery() : IRequest<ErrorOr<List<RetailDataProviderViewModel>>>;
