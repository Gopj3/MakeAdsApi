using System;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using MakeAdsApi.Application.Common.Abstractions.Helpers;
using MakeAdsApi.Application.Common.Abstractions.Services.AWS;
using MakeAdsApi.Application.Enums;
using Microsoft.AspNetCore.Http;

namespace MakeAdsApi.Application.Services.Helpers;

public class FilesHelper : IFilesHelper
{
    private readonly HttpClient _httpClient;
    private readonly IAwsS3Service _s3Service;

    public FilesHelper(HttpClient httpClient, IAwsS3Service awsS3Service)
    {
        _httpClient = httpClient;
        _s3Service = awsS3Service;
    }

    public async Task<MemoryStream> UrlToMemoryStreamAsync(string url)
    {
        var response = await _httpClient.GetAsync(url);
        var bytes = await response.Content.ReadAsByteArrayAsync();

        return new MemoryStream(bytes);
    }

    public async Task<string?> UploadImageFormFileToAwsAsync(IFormFile? formFile, Folders folder,
        CancellationToken cancellationToken = default)
    {
        if (formFile is not null)
        {
            if (await _s3Service.WriteObjectAsync(formFile, folder, cancellationToken))
            {
                return _s3Service.GetPreSignedUrl(formFile.FileName);
            }
        }

        return null;
    }

    public async Task<string?> UploadImageToAwsFromUrlAsync(
        string url,
        Folders folder,
        string? fileName = null,
        CancellationToken cancellationToken = default
    )
    {
        if (fileName is null)
        {
            var extension = ExtensionFromUrl(url);
            fileName = GenerateFileName(extension);
        }

        var stream = await UrlToMemoryStreamAsync(url);
        if (await _s3Service.WriteObjectAsync(stream, folder, fileName, cancellationToken))
        {
            var createdFileName = folder + "/" + fileName;
            await stream.DisposeAsync();
            return _s3Service.GetPreSignedUrl(createdFileName);
        }
        
        await stream.DisposeAsync();
        return null;
    }
    
    public string? GetFileNameFromPreSignedUrl(string preSignedUrl)
    {
        var awsPreSignedPart = "Expires";
        if (preSignedUrl.Contains(awsPreSignedPart))
        {
            var firstPart = preSignedUrl.Split("?").First();
            return firstPart.Split("/").Last();
        }

        return null;
    }

    public string ExtensionFromUrl(string url)
    {
        return url.Split(".").Last();
    }

    public string GenerateFileName(string extension)
    {
        return Guid.NewGuid() + $".{extension}";
    }
}