using System;
using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using MakeAdsApi.Application.Common.Abstractions.Repositories;

namespace MakeAdsApi.Application.Offices.Admin.Commands;

public class CreateUpdateCommandsValidator<TCommand>: AbstractValidator<TCommand>
{
    protected readonly IUnitOfWork _unitOfWork;

    public CreateUpdateCommandsValidator(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    
    protected async Task<bool> CompanyShouldExistsAsync(Guid companyId, CancellationToken cancellationToken = default)
    {
        var company = await _unitOfWork.CompanyRepository.GetByIdAsync(companyId, cancellationToken);
        
        return company is not null;
    }
}