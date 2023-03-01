using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MakeAdsApi.Application.Common.Abstractions.Jobs;
using MakeAdsApi.Application.Common.Abstractions.Repositories;
using MakeAdsApi.Application.Common.Abstractions.Services.AWS;
using MakeAdsApi.Domain.Entities.Files;
using Microsoft.IdentityModel.Tokens;

namespace MakeAdsApi.Infrastructure.Jobs;

public class UpdatePreSignedUrlsService: IUpdatePreSignedUrlsService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IAwsS3Service _awsS3Service;

    public UpdatePreSignedUrlsService(IUnitOfWork unitOfWork, IAwsS3Service awsS3Service)
    {
        _unitOfWork = unitOfWork;
        _awsS3Service = awsS3Service;
    }

    public async Task UpdatePreSignedUrlsAsync(CancellationToken cancellationToken = default)
    {
        List<File> filesToUpdate =
            await _unitOfWork.FileRepository.GetNeedsToBeUpdatedAsync(cancellationToken);
        
        if (filesToUpdate.Any())
        {
            filesToUpdate.ForEach(file =>
            {
                var url = _awsS3Service.GetPreSignedUrl(file.FileName);
                if (!url.IsNullOrEmpty())
                {
                    file.PreSignedUrl = url;
                    file.PreSignedUrlCreatedAt = DateTime.UtcNow;
                }
                
                _unitOfWork.FileRepository.Update(file);
            });

            await _unitOfWork.SaveChangesAsync(cancellationToken);
        }
    }
}