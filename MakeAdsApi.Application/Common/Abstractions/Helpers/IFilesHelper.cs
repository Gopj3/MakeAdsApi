using System.IO;
using System.Threading;
using System.Threading.Tasks;
using MakeAdsApi.Application.Enums;
using Microsoft.AspNetCore.Http;

namespace MakeAdsApi.Application.Common.Abstractions.Helpers;

public interface IFilesHelper
{
    Task<MemoryStream> UrlToMemoryStreamAsync(string url);
    string ExtensionFromUrl(string url);
    string GenerateFileName(string extension);
    string? GetFileNameFromPreSignedUrl(string preSignedUrl);
    Task<string?> UploadImageFormFileToAwsAsync(IFormFile? formFile, Folders folder, CancellationToken cancellationToken = default);
    Task<string?> UploadImageToAwsFromUrlAsync(string url, Folders folder, string? fileName = null,
        CancellationToken cancellationToken = default);
}