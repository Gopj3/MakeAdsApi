using FluentValidation;

namespace MakeAdsApi.Application.Companies.Admin.Queries.Single;

public class GetCompanyByIdQueryValidator: AbstractValidator<GetCompanyByIdQuery>
{
    public GetCompanyByIdQueryValidator()
    {
        RuleFor(x => x.Id).NotNull().NotEmpty();
    }
}