using FluentValidation;

namespace MakeAdsApi.Application.Users.Commands;

public class EditUserCommandValidator: AbstractValidator<EditUserCommand>
{
    public EditUserCommandValidator()
    {
        RuleFor(x => x.Id).NotNull().NotEmpty();
        RuleFor(x => x.Email).NotNull().NotEmpty();
        RuleFor(x => x.RoleIds).NotNull().NotEmpty();
    }
}