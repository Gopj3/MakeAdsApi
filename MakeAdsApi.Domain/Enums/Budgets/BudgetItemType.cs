using Ardalis.SmartEnum;

namespace MakeAdsApi.Domain.Enums.Budgets;

public class BudgetItemType: SmartEnum<BudgetItemType, string>
{
    public static readonly BudgetItemType Facebook = new (nameof(Facebook), nameof(Facebook).ToLower()); 
    public static readonly BudgetItemType Delta = new (nameof(Delta), nameof(Delta).ToLower()); 
    public static readonly BudgetItemType SnapChat = new (nameof(SnapChat), nameof(SnapChat).ToLower()); 
    public static readonly BudgetItemType LinkedIn = new (nameof(LinkedIn), nameof(LinkedIn).ToLower()); 
    
    public BudgetItemType(string name, string value) : base(name, value)
    {
    }
}