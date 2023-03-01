using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Amazon.S3;
using MakeAdsApi.Application.Enums;
using Microsoft.AspNetCore.Http;

namespace MakeAdsApi.Application.Common.Abstractions.Services.AWS;

public interface IAwsS3Service
{
    public Task<bool> WriteObjectAsync(IFormFile formFile, Folders folder, CancellationToken cancellationToken = default);

    public Task<bool> WriteObjectAsync(MemoryStream stream, Folders folder, string fileName,
        CancellationToken cancellationToken = default);

    public string GetPreSignedUrl(string fileName);
    public string GetPreSignedBasedOnUnPreSignedUrl(string url);
    public Task DeleteFileByFileNameAsync(string fileName);
}