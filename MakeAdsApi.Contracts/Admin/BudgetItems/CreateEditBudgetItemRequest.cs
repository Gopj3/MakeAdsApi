namespace MakeAdsApi.Contracts.Admin.BudgetItems;

public record CreateEditBudgetItemRequest(
    string BudgetId,
    decimal Value,
    string Type
);