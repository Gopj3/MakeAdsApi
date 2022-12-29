namespace MakeAdsApi.Contracts.Authentication;

public record SelfRegisterUserRequest(
    string Email,
    string Password,
    string ConfirmPassword
);