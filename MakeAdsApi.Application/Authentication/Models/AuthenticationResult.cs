namespace MakeAdsApi.Application.Authentication.Models;

public record AuthenticationResult(
    string Email,
    string AccessToken,
    int ExpiresIn
);