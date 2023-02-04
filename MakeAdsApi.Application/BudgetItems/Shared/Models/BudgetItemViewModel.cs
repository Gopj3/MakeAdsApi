using MakeAdsApi.Application.Common.ViewModels;
using MakeAdsApi.Domain.Entities.Budgets;

namespace MakeAdsApi.Application.BudgetItems.Shared.Models;

public class BudgetItemViewModel: BaseViewModel
{
    public decimal Value { get; set; }
    public string Type { get; set; }

    public static BudgetItemViewModel From(BudgetItem budgetItem)
    {
        return new BudgetItemViewModel
        {
            Id = budgetItem.Id,
            Type = budgetItem.Type.Value,
            Value = budgetItem.Value,
            CreatedAt = budgetItem.CreatedAt.ToLongDateString()
        };
    }
}