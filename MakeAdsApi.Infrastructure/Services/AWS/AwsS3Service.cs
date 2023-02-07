using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Amazon;
using Amazon.Runtime;
using Amazon.S3;
using Amazon.S3.Model;
using MakeAdsApi.Application.Common.Abstractions.Services.AWS;
using MakeAdsApi.Infrastructure.Common.AWS;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace MakeAdsApi.Infrastructure.Services.AWS;

public class AwsS3Service : IAwsS3Service
{
    private const string S3_ERROR = "Error encountered on server. Message:'{0}' when writing an object";
    private const string UNHANDLED_EXCEPTION = "Error encountered on server. Message:'{0}' when writing an object";

    private readonly AwsSettings _awsSettings;
    private readonly IAmazonS3 _s3Client;
    private readonly ILogger<AwsS3Service> _logger;

    public AwsS3Service(
        IOptions<AwsSettings> awsSettingsOptions,
        ILogger<AwsS3Service> logger
    )
    {
        _awsSettings = awsSettingsOptions.Value;
        _logger = logger;
        _s3Client = new AmazonS3Client(
            new BasicAWSCredentials(_awsSettings.Key, _awsSettings.Secret),
            RegionEndpoint.GetBySystemName(_awsSettings.Region)
        );
    }

    public async Task<bool> WriteObjectAsync(MemoryStream stream, string fileName,
        CancellationToken cancellationToken = default)
    {
        try
        {
            var request = new PutObjectRequest
            {
                BucketName = _awsSettings.BucketName,
                Key = fileName,
                InputStream = stream
            };

            await _s3Client.PutObjectAsync(request, cancellationToken);

            return true;
        }
        catch (AmazonS3Exception e)
        {
            _logger.LogError(e, S3_ERROR, e.Message);
        }
        catch (Exception e)
        {
            _logger.LogError(e, UNHANDLED_EXCEPTION, e.Message);
        }

        return false;
    }

    public async Task<bool> WriteObjectAsync(IFormFile formFile, CancellationToken cancellationToken = default)
    {
        try
        {
            var request = new PutObjectRequest
            {
                BucketName = _awsSettings.BucketName,
                Key = formFile.FileName,
                InputStream = formFile.OpenReadStream()
            };

            await _s3Client.PutObjectAsync(request, cancellationToken);

            return true;
        }
        catch (AmazonS3Exception e)
        {
            _logger.LogError(e, S3_ERROR, e.Message);
        }
        catch (Exception e)
        {
            _logger.LogError(e, UNHANDLED_EXCEPTION, e.Message);
        }

        return false;
    }

    public string GetPreSignedUrl(string fileName)
    {
        string url = String.Empty;
        try
        {
            GetPreSignedUrlRequest request = new GetPreSignedUrlRequest
            {
                BucketName = _awsSettings.BucketName,
                Key = fileName,
                Expires = DateTime.UtcNow.AddDays(7)
            };

            url = _s3Client.GetPreSignedURL(request);
        }
        catch (AmazonS3Exception e)
        {
            _logger.LogError(e, S3_ERROR, e.Message);
        }
        catch (Exception e)
        {
            _logger.LogError(e, UNHANDLED_EXCEPTION, e.Message);
        }

        return url;
    }

    public string GetPreSignedBasedOnUnPreSignedUrl(string url)
    {
        string fileName = String.Empty;

        if (url.Contains(_awsSettings.BucketUrl))
        {
            StringBuilder sb = new StringBuilder(url);
            sb.Replace(_awsSettings.BucketUrl, "");
            fileName = sb.ToString();
        }

        return GetPreSignedUrl(fileName);
    }

    public async Task DeleteFileByFileNameAsync(string fileName)
    {
        try
        {
            var request = new DeleteObjectRequest
            {
                BucketName = _awsSettings.BucketName,
                Key = fileName
            };

            await _s3Client.DeleteObjectAsync(request);
        }
        catch (AmazonS3Exception e)
        {
            _logger.LogError(e, S3_ERROR, e.Message);
        }
        catch (Exception e)
        {
            _logger.LogError(e, UNHANDLED_EXCEPTION, e.Message);
        }
    }
}