using System;
using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using MakeAdsApi.Application.Common.Abstractions.Repositories;

namespace MakeAdsApi.Application.Offices.Admin.Commands;

public class UpdateOfficeCommandValidator: CreateUpdateCommandsValidator<UpdateOfficeCommand>
{
    public UpdateOfficeCommandValidator(IUnitOfWork unitOfWork) : base(unitOfWork)
    {
        RuleFor(x => x.Id).NotNull().NotEmpty();
        RuleFor(x => x.Title).NotNull().NotEmpty();
        RuleFor(x => x.ExternalId).NotNull().NotEmpty();
        RuleFor(x => x.CompanyId)
            .NotNull()
            .NotEmpty()
            .MustAsync(CompanyShouldExistsAsync)
            .WithMessage("Provided company does not exists");
    }
}