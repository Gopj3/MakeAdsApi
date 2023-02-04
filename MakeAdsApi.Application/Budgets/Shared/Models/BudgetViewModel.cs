using System;
using System.Collections.Generic;
using System.Linq;
using MakeAdsApi.Application.BudgetItems.Shared.Models;
using MakeAdsApi.Application.Common.ViewModels;
using MakeAdsApi.Domain.Entities.Budgets;

namespace MakeAdsApi.Application.Budgets.Shared.Models;

public class BudgetViewModel: BaseViewModel
{
    public string Title { get; set; }
    public string Type { get; set; }
    public Guid CompanyId { get; set; }
    public List<BudgetItemViewModel>? BudgetItems { get; set; }
    
    public static BudgetViewModel From(Budget budget)
    {
        return new BudgetViewModel
        {
            Id = budget.Id,
            Title = budget.Title,
            Type = budget.Type.Value,
            CompanyId = budget.CompanyId,
            BudgetItems = budget.BudgetItems?.Select(BudgetItemViewModel.From).ToList(),
            CreatedAt = budget.CreatedAt.ToLongDateString(),
        };
    }
}