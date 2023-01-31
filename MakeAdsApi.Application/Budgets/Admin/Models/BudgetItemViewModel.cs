using MakeAdsApi.Application.Common.ViewModels;
using MakeAdsApi.Domain.Entities.Budgets;

namespace MakeAdsApi.Application.Budgets.Admin.Models;

public class BudgetItemViewModel: BaseViewModel
{
    public decimal Value { get; set; }
    public string Type { get; set; }

    public static BudgetItemViewModel From(BudgetItem budgetItem)
    {
        return new BudgetItemViewModel
        {
            Value = budgetItem.Value,
            Type = budgetItem.Type.Value
        };
    }
}