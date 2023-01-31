using System;
using ErrorOr;
using MakeAdsApi.Application.Offices.Admin.Models;
using MediatR;

namespace MakeAdsApi.Application.Offices.Admin.Queries.Single;

public record GetOfficeByIdQuery(Guid Id) : IRequest<ErrorOr<OfficeViewModel>>;
