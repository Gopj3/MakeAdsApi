using System;
using ErrorOr;
using MakeAdsApi.Application.RetailProviders.Admin.Models;
using MediatR;

namespace MakeAdsApi.Application.RetailProviders.Admin.Queries.Single;

public record SingleRetailDataProviderByIdQuery(
    Guid Id
) : IRequest<ErrorOr<RetailDataProviderViewModel>>;