using FluentValidation;

namespace MakeAdsApi.Application.Users.Queries.Lists;

public class GetPaginatedUserQueryValidator: AbstractValidator<GetPaginatedUserQuery>
{
    public GetPaginatedUserQueryValidator()
    {
        RuleFor(x => x.Page).NotNull();
        RuleFor(x => x.PageSize).NotNull().GreaterThan(0);
    }
}