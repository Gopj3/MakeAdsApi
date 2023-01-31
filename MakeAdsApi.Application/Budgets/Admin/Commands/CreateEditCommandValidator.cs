using System;
using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using MakeAdsApi.Application.Common.Abstractions.Repositories;

namespace MakeAdsApi.Application.Budgets.Admin.Commands;

public class CreateEditCommandValidator<T>: AbstractValidator<T>
{
    protected readonly IUnitOfWork _unitOfWork;

    public CreateEditCommandValidator(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    
    protected async Task<bool> CompanyShouldExistsAsync(Guid companyId, CancellationToken cancellationToken = default)
    {
        var company = await _unitOfWork.CompanyRepository.GetByIdAsync(companyId, cancellationToken);
        
        return company is not null;
    }
}