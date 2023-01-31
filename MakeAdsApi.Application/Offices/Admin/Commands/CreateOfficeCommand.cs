using System;
using ErrorOr;
using MakeAdsApi.Application.Offices.Admin.Models;
using MediatR;

namespace MakeAdsApi.Application.Offices.Admin.Commands;

public record CreateOfficeCommand(
    string Title,
    string ExternalId,
    Guid CompanyId
) : IRequest<ErrorOr<OfficeViewModel>>;