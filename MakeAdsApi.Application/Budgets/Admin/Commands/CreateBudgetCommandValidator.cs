using FluentValidation;
using MakeAdsApi.Application.Common.Abstractions.Repositories;

namespace MakeAdsApi.Application.Budgets.Admin.Commands;

public class CreateBudgetCommandValidator: CreateEditCommandValidator<CreateBudgetCommand>
{
    public CreateBudgetCommandValidator(IUnitOfWork unitOfWork) : base(unitOfWork)
    {
        RuleFor(x => x.Title).NotNull().NotEmpty();
        RuleFor(x => x.CompanyId)
            .NotNull()
            .NotEmpty()
            .MustAsync(CompanyShouldExistsAsync)
            .WithMessage("Company not found");
    }
}