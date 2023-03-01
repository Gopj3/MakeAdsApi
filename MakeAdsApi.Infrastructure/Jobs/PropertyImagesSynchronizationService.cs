using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MakeAdsApi.Application.Common.Abstractions.Helpers;
using MakeAdsApi.Application.Common.Abstractions.Jobs;
using MakeAdsApi.Application.Common.Abstractions.Repositories;
using MakeAdsApi.Application.Common.Abstractions.Services.RetailDataProviders;
using MakeAdsApi.Application.Enums;
using MakeAdsApi.Application.RetailProviders.Common.Models;
using MakeAdsApi.Domain.Entities.Files.MediaLibrary;
using MakeAdsApi.Domain.Entities.Properties;
using MakeAdsApi.Domain.Entities.Users;
using Microsoft.Extensions.Logging;

namespace MakeAdsApi.Infrastructure.Jobs;

public class PropertyImagesSynchronizationService : IPropertyImagesSynchronizationService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IRetailDataProviderHttpService _retailDataProviderHttpService;
    private readonly IFilesHelper _filesHelper;
    private readonly ILogger<PropertyImagesSynchronizationService> _logger;

    public PropertyImagesSynchronizationService(
        IUnitOfWork unitOfWork,
        IRetailDataProviderHttpService retailDataProviderHttpService,
        IFilesHelper filesHelper,
        ILogger<PropertyImagesSynchronizationService> logger
    )
    {
        _unitOfWork = unitOfWork;
        _retailDataProviderHttpService = retailDataProviderHttpService;
        _filesHelper = filesHelper;
        _logger = logger;
    }

    public async Task SynchronizePropertyImagesAsync(
        Guid propertyId,
        Guid userId,
        CancellationToken cancellationToken = default
    )
    {
        var user = await _unitOfWork.UserRepository.GetWithOfficeAndCompanyByIdAsync(userId, cancellationToken);
        var property = await _unitOfWork.PropertyRepository.GetByIdAsync(propertyId, cancellationToken);

        var apiResponse = await GetRetailPropertyDataAsync(user!, property!.PropertyId, cancellationToken);
        if (apiResponse is null) return;

        var propertyImages = await _unitOfWork.MediaLibraryImageRepository
            .GetByExpressionAsync(x => x.Property == property, cancellationToken);

        var toBeInserted = CollectImagesToBeInserted(apiResponse, propertyImages);

        await BatchCreateMediaLibraryImagesAsync(toBeInserted, property, cancellationToken);
    }

    private async Task<RetailDataPropertyApiResponse?> GetRetailPropertyDataAsync(
        User user,
        string propertyId,
        CancellationToken cancellationToken)
    {
        var retailProviderData =
            await _unitOfWork.RetailDataProviderRepository.GetByExpressionFirstAsync(
                x => x.Companies.Contains(user!.Office!.Company),
                cancellationToken);

        var apiResponse = await _retailDataProviderHttpService.GetRetailPropertyDataAsync(
            retailProviderData!.FetchPropertyDataUrl!,
            user!.Office!.Company.ExternalId,
            propertyId,
            cancellationToken
        );

        return apiResponse;
    }

    private List<string> CollectImagesToBeInserted(RetailDataPropertyApiResponse apiResponse,
        List<MediaLibraryImage>? propertyImages)
    {
        if (propertyImages != null && propertyImages.Any())
        {
            var toBeInserted = new List<string>();
            apiResponse.PropertyImages.ForEach(
                x =>
                {
                    var contains = propertyImages.Any(file => file.ExternalUrl == x);
                    if (!contains) toBeInserted.Add(x);
                });

            return toBeInserted;
        }

        return apiResponse.PropertyImages;
    }

    private async Task BatchCreateMediaLibraryImagesAsync(
        List<string> images,
        Property property,
        CancellationToken cancellationToken
    )
    {
        var throttler = new SemaphoreSlim(5);
        var tasks = images.Select(async value =>
        {
            await throttler.WaitAsync(cancellationToken);
            try
            {
                return await _filesHelper.UploadImageToAwsFromUrlAsync(
                    value,
                    Folders.Medias,
                    null,
                    cancellationToken
                );
            }
            catch (Exception exception)
            {
                _logger.LogError(
                    exception,
                    "Error while synchronizing images from property. Error message {ExceptionMessage}",
                    exception.Message
                );
            }
            finally
            {
                throttler.Release();
            }

            return null;
        });

        var res = await Task.WhenAll(tasks);

        for (var index = 0; index < res.Length; index++)
        {
            if (res[index] is null) continue;

            var splitUrl = _filesHelper.GetFileNameFromPreSignedUrl(res[index]!)?.Split(".");
            if (splitUrl is null) continue;

            var mediaFile = new MediaLibraryImage
            {
                Id = Guid.NewGuid(),
                Property = property,
                FileName = splitUrl.First() + "." + splitUrl.Last(),
                FileExtension = splitUrl.Last(),
                PreSignedUrl = res[index],
                PreSignedUrlCreatedAt = DateTime.UtcNow,
                ExternalUrl = images[index]
            };

            await _unitOfWork.MediaLibraryImageRepository.CreateAsync(mediaFile, cancellationToken);
        }

        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}