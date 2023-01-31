namespace MakeAdsApi.Contracts.Admin.Companies;

public record CreateEditCompanyRequest(
    string Title,
    string ExternalId,
    string RetailDataProviderId
);
