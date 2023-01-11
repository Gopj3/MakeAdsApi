using FluentValidation;

namespace MakeAdsApi.Application.Users.Queries.Lists;

public class GetPaginatedUserQueryValidator: AbstractValidator<GetPaginatedUserQuery>
{
    public GetPaginatedUserQueryValidator()
    {
        RuleFor(x => x.Page).GreaterThan(0);
        RuleFor(x => x.PageSize).GreaterThan(0);
    }
}