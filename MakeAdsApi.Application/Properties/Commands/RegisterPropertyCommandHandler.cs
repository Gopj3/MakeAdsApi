using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using ErrorOr;
using Hangfire;
using MakeAdsApi.Application.Common.Abstractions.Jobs;
using MakeAdsApi.Application.Common.Abstractions.Repositories;
using MakeAdsApi.Application.Properties.Models;
using MakeAdsApi.Domain.Entities.Properties;
using MakeAdsApi.Domain.Errors;
using MediatR;

namespace MakeAdsApi.Application.Properties.Commands;

public class RegisterPropertyCommandHandler : IRequestHandler<RegisterPropertyCommand, ErrorOr<PropertyViewModel>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public RegisterPropertyCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<ErrorOr<PropertyViewModel>> Handle(
        RegisterPropertyCommand request,
        CancellationToken cancellationToken)
    {
        var property = await _unitOfWork.PropertyRepository.GetByExpressionFirstAsync(
            x => x.PropertyId == request.PropertyId,
            cancellationToken
        );

        var user = await _unitOfWork.UserRepository.GetWithOfficeAndCompanyByIdAsync(
            request.UserId,
            cancellationToken
        );

        if (user is null)
        {
            return DomainErrors.User.NotFound;
        }

        if (property is null)
        {
            Guid propertyId = Guid.NewGuid();
            var propertyUsers = new List<PropertyUser> { new() { PropertyId = propertyId, UserId = user.Id } };

            property = new Property
            {
                Id = Guid.NewGuid(),
                Address = request.Address,
                PropertyId = request.PropertyId,
                IsSold = false,
                Users = propertyUsers
            };

            await _unitOfWork.PropertyRepository.CreateAsync(property, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
        }

        BackgroundJob.Enqueue<IPropertyImagesSynchronizationService>(
            x => x.SynchronizePropertyImagesAsync(property.Id, user.Id, cancellationToken)
        );

        return _mapper.Map<PropertyViewModel>(property);
    }
}