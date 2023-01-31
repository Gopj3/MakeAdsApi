using FluentValidation;

namespace MakeAdsApi.Application.Offices.Admin.Queries.List;

public class PaginatedOfficesQueryValidator: AbstractValidator<PaginatedOfficesQuery>
{
    public PaginatedOfficesQueryValidator()
    {
        RuleFor(x => x.Page).NotNull();
        RuleFor(x => x.PageSize).NotNull().GreaterThan(0);
    }
}