using FluentValidation;

namespace MakeAdsApi.Application.Companies.Admin.Commands;

public class UpdateCompanyCommandValidator: AbstractValidator<UpdateCompanyCommand>
{
    public UpdateCompanyCommandValidator()
    {
        RuleFor(x => x.Id).NotNull().NotEmpty();
        RuleFor(x => x.Title).NotNull().NotEmpty();
        RuleFor(x => x.ExternalId).NotNull().NotEmpty();
        RuleFor(x => x.RetailDataProviderId).NotNull().NotEmpty();
    }
}  