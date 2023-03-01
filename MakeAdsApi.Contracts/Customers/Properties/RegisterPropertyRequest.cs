namespace MakeAdsApi.Contracts.Customers.Properties;

public record RegisterPropertyRequest(
    string PropertyId,
    string Address
);