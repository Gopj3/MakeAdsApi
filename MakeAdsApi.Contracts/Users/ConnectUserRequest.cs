namespace MakeAdsApi.Contracts.Users;

public record ConnectUserRequest(
    string CompanyId,
    string PropertyId
);