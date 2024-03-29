using FluentValidation;

namespace MakeAdsApi.Application.Budgets.Admin.Queries.Lists;

public class PaginatedBudgetsQueryValidator: AbstractValidator<PaginatedBudgetsQuery>
{
    public PaginatedBudgetsQueryValidator()
    {
        RuleFor(x => x.Page).NotNull();
        RuleFor(x => x.PageSize).NotNull().GreaterThan(0);
    }
}