using System;
using ErrorOr;
using MakeAdsApi.Application.Companies.Admin.Models;
using MediatR;

namespace MakeAdsApi.Application.Companies.Admin.Queries.Single;

public record GetCompanyByIdQuery(Guid Id) : IRequest<ErrorOr<CompanyViewModel>>;