using FluentValidation;

namespace MakeAdsApi.Application.Users.Commands.Admin;

public class CreateUserCommandValidator: AbstractValidator<CreateUserCommand>
{
    public CreateUserCommandValidator()
    {
        RuleFor(x => x.Email).NotEmpty().EmailAddress();
        RuleFor(x => x.RoleIds).NotEmpty();
    }
}