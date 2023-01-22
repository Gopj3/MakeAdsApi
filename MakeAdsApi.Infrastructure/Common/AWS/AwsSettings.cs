namespace MakeAdsApi.Infrastructure.Common.AWS;

public class AwsSettings
{
    public string Key { get; set; }
    public string Secret { get; set; }
    public string BucketName { get; set; }
    public string Region { get; set; }
    public string BucketUrl { get; set; }
}