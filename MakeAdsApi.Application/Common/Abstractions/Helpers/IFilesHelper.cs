using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace MakeAdsApi.Application.Common.Abstractions.Helpers;

public interface IFilesHelper
{
    Task<MemoryStream> UrlToMemoryStream(string url);
    string ExtensionFromUrl(string url);
    string GenerateFileName(string extension);
    Task<string?> UploadImageFormFileToAwsAsync(IFormFile? formFile, CancellationToken cancellationToken = default);
    Task<string?> UploadImageToAwsFromUrlAsync(string url, string? fileName = null,
        CancellationToken cancellationToken = default);
}