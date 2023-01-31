using FluentValidation;

namespace MakeAdsApi.Application.Companies.Admin.Commands;

public class CreateCompanyCommandValidator: AbstractValidator<CreateCompanyCommand>
{
    public CreateCompanyCommandValidator()
    {
        RuleFor(x => x.Title).NotNull().NotEmpty();
        RuleFor(x => x.RetailDataProviderId).NotNull().NotEmpty();
        RuleFor(x => x.ExternalId).NotNull().NotEmpty();
    }
}