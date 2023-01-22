using System.Threading;
using System.Threading.Tasks;
using Amazon.S3;
using Microsoft.AspNetCore.Http;

namespace MakeAdsApi.Application.Common.Abstractions.Services.AWS;

public interface IAwsS3Service
{
    public Task WriteObjectAsync(IFormFile formFile, CancellationToken cancellationToken = default);
    public string GetPreSignedUrlAsync(string fileName, HttpVerb? httpVerb = null);
    public string GetPreSignedBasedOnUnPreSignedUrlAsync(string url);
    public Task DeleteFileByFileNameAsync(string fileName);
    public Task<string?> WriteObjectWithPreSignedUrlAsync(IFormFile file,
        CancellationToken cancellationToken = default);
}