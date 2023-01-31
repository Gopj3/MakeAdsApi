namespace MakeAdsApi.Contracts.Admin.Offices;

public record CreateEditOfficeRequest(
    string Title,
    string ExternalId,
    string CompanyId
);