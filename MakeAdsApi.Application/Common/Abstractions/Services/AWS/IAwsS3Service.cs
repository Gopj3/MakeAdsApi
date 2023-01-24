using System.Threading;
using System.Threading.Tasks;
using Amazon.S3;
using Microsoft.AspNetCore.Http;

namespace MakeAdsApi.Application.Common.Abstractions.Services.AWS;

public interface IAwsS3Service
{
    public Task<bool> WriteObjectAsync(IFormFile formFile, CancellationToken cancellationToken = default);
    public string GetPreSignedUrl(string fileName);
    public string GetPreSignedBasedOnUnPreSignedUrl(string url);
    public Task DeleteFileByFileNameAsync(string fileName);
}