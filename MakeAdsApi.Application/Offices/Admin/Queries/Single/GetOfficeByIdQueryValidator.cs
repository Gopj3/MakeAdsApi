using FluentValidation;

namespace MakeAdsApi.Application.Offices.Admin.Queries.Single;

public class GetOfficeByIdQueryValidator: AbstractValidator<GetOfficeByIdQuery>
{
    public GetOfficeByIdQueryValidator()
    {
        RuleFor(x => x.Id).NotNull().NotEmpty();
    }
}