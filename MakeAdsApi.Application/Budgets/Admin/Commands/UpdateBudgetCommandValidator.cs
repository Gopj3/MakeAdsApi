using FluentValidation;
using MakeAdsApi.Application.Common.Abstractions.Repositories;
using MediatR;

namespace MakeAdsApi.Application.Budgets.Admin.Commands;

public class UpdateBudgetCommandValidator: CreateEditCommandValidator<UpdateBudgetCommand>
{
    public UpdateBudgetCommandValidator(IUnitOfWork unitOfWork): base(unitOfWork)
    {
        RuleFor(x => x.Id).NotNull().NotEmpty();
        RuleFor(x => x.Title).NotNull().NotEmpty();
        RuleFor(x => x.CompanyId)
            .NotNull()
            .NotEmpty()
            .MustAsync(CompanyShouldExistsAsync)
            .WithMessage("Company not found");
    }
}