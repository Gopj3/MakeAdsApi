using System;
using ErrorOr;
using MakeAdsApi.Application.RetailProviders.Common.Models;
using MediatR;

namespace MakeAdsApi.Application.RetailProviders.User.Queries;

public record GetRetailDataForPropertyQuery(
    string PropertyId,
    Guid LoggedInUserId
) : IRequest<ErrorOr<RetailDataApiResponseViewModel>>;