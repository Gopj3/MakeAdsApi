using System.Collections.Generic;
using ErrorOr;
using MakeAdsApi.Application.Companies.Admin.Models;
using MediatR;

namespace MakeAdsApi.Application.Companies.Admin.Queries.List;

public record GetAllCompaniesQuery() : IRequest<ErrorOr<List<CompanyViewModel>>>;
