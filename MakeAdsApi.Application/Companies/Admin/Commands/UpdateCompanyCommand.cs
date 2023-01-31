using System;
using ErrorOr;
using MakeAdsApi.Application.Companies.Admin.Models;
using MediatR;

namespace MakeAdsApi.Application.Companies.Admin.Commands;

public record UpdateCompanyCommand(
    Guid Id,
    string Title,
    string ExternalId,
    Guid RetailDataProviderId
) : IRequest<ErrorOr<CompanyViewModel>>;
