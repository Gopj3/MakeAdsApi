namespace MakeAdsApi.Contracts.Admin.Budgets;

public record CreateEditBudgetRequest(string Title, string Type, string CompanyId);