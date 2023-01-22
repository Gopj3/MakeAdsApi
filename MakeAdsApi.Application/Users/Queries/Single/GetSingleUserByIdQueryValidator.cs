using FluentValidation;

namespace MakeAdsApi.Application.Users.Queries.Single;

public class GetSingleUserByIdQueryValidator: AbstractValidator<GetSingleUserByIdQuery>
{
    public GetSingleUserByIdQueryValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
    }
}