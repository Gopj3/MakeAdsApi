using Ardalis.SmartEnum;

namespace MakeAdsApi.Domain.Enums.Budgets;

public class BudgetItemType : SmartEnum<BudgetItemType, string>
{
    public static readonly BudgetItemType Facebook = new(nameof(Facebook).ToLower(), nameof(Facebook).ToLower());
    public static readonly BudgetItemType Delta = new(nameof(Delta).ToLower(), nameof(Delta).ToLower());
    public static readonly BudgetItemType Snapchat = new(nameof(Snapchat).ToLower(), nameof(Snapchat).ToLower());
    public static readonly BudgetItemType LinkedIn = new(nameof(LinkedIn).ToLower(), nameof(LinkedIn).ToLower());

    public BudgetItemType(string name, string value) : base(name, value)
    {
    }
}