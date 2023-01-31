using FluentValidation;

namespace MakeAdsApi.Application.Companies.Admin.Queries.List;

public class PaginatedCompaniesQueryValidator: AbstractValidator<PaginatedCompaniesQuery>
{
    public PaginatedCompaniesQueryValidator()
    {
        RuleFor(x => x.Page).NotNull();
        RuleFor(x => x.PageSize).NotNull().GreaterThan(0);
    }
}