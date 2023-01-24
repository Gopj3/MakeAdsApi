using FluentValidation;

namespace MakeAdsApi.Application.UserProfiles.Admin.Queries;

public class GetUserProfileQueryValidator: AbstractValidator<GetUserProfileQuery>
{
    public GetUserProfileQueryValidator()
    {
        RuleFor(x => x.UserId).NotNull().NotEmpty();
    }
}