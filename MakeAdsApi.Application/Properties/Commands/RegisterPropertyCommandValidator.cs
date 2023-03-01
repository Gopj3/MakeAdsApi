using FluentValidation;

namespace MakeAdsApi.Application.Properties.Commands;

public class RegisterPropertyCommandValidator: AbstractValidator<RegisterPropertyCommand>
{
    public RegisterPropertyCommandValidator()
    {
        RuleFor(x => x.PropertyId)
            .NotEmpty()
            .NotNull()
            .WithMessage("PropertyId is required");
        RuleFor(x => x.Address)
            .NotEmpty()
            .NotNull()
            .WithMessage("Address is required");
    }
}