using FluentValidation;

namespace MakeAdsApi.Application.RetailProviders.Admin.Commands;

public class CreateRetailDataProviderValidator: AbstractValidator<CreateRetailDataProviderCommand>
{
    public CreateRetailDataProviderValidator()
    {
        RuleFor(x => x.Title).NotNull().NotEmpty();
    }
}