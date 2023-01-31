using System;
using MakeAdsApi.Domain.Enums.Budgets;

namespace MakeAdsApi.Domain.Entities.Budgets;

public class BudgetItem: BaseEntity
{
    public decimal Value { get; set; }
    public BudgetItemType Type { get; set; }
    public Guid BudgetId { get; set; }
    public Budget Budget { get; set; }

    public BudgetItem(Guid budgetId, decimal value, BudgetItemType type)
    {
        BudgetId = budgetId;
        Value = value;
        Type = type;
    }
}