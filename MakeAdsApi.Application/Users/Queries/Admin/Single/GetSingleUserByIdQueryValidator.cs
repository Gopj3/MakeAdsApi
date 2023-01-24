using FluentValidation;

namespace MakeAdsApi.Application.Users.Queries.Admin.Single;

public class GetSingleUserByIdQueryValidator: AbstractValidator<GetSingleUserByIdQuery>
{
    public GetSingleUserByIdQueryValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
    }
}