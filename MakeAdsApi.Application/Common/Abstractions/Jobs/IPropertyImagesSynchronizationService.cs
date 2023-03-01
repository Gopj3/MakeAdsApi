using System;
using System.Threading;
using System.Threading.Tasks;
using MakeAdsApi.Domain.Entities.Properties;
using MakeAdsApi.Domain.Entities.Users;

namespace MakeAdsApi.Application.Common.Abstractions.Jobs;

public interface IPropertyImagesSynchronizationService
{
    public Task SynchronizePropertyImagesAsync(
        Guid propertyId,
        Guid userId,
        CancellationToken cancellationToken = default
    );
}