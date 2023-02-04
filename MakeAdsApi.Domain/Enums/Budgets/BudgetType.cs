using Ardalis.SmartEnum;

namespace MakeAdsApi.Domain.Enums.Budgets;

public class BudgetType: SmartEnum<BudgetType, string>
{
    public static readonly BudgetType Regular = new(nameof(Regular).ToLower(), nameof(Regular).ToLower());
    public static readonly BudgetType Automatic = new(nameof(Automatic).ToLower(), nameof(Automatic).ToLower());
    public static readonly BudgetType AfterSold = new(nameof(AfterSold).ToLower(), nameof(AfterSold).ToLower());
    
    public BudgetType(string name, string value) : base(name, value)
    {
    }
}