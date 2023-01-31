namespace MakeAdsApi.Domain.Entities.Files.MediaLibrary;

public class MediaLibraryImage : BaseMediaLibraryFile
{
    public MediaLibraryImage(
        string fileName,
        string fileExtension,
        string? preSignedUrl
    ) : base(fileName, fileExtension, preSignedUrl)
    {
    }
}