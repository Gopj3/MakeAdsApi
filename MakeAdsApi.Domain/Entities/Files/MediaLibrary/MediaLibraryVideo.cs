namespace MakeAdsApi.Domain.Entities.Files.MediaLibrary;

public class MediaLibraryVideo : BaseMediaLibraryFile
{
    public string? FacebookId { get; set; }
    public string? SnapChatId { get; set; }

    public MediaLibraryVideo(
        string fileName,
        string fileExtension,
        string? preSignedUrl
    ) : base(fileName, fileExtension, preSignedUrl)
    {
    }
}