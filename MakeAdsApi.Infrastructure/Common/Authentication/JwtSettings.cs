namespace MakeAdsApi.Infrastructure.Common.Authentication
{
    public class JwtSettings
    {
        public string Secret { get; set; }
        public string Issuer { get; set; }
        public int ExpiresIn { get; set; }
    }
}