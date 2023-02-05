namespace MakeAdsApi.Contracts.Outer;

public record InitiateUserRequest(
    string CompanyId,
    string PropertyId
);