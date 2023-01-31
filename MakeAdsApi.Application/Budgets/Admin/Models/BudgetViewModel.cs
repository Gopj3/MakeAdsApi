using System;
using System.Collections.Generic;
using System.Linq;
using MakeAdsApi.Application.Common.ViewModels;
using MakeAdsApi.Domain.Entities.Budgets;

namespace MakeAdsApi.Application.Budgets.Admin.Models;

public class BudgetViewModel: BaseViewModel
{
    public string Title { get; set; }
    public Guid CompanyId { get; set; }
    public string? CompanyTitle { get; set; }
    public List<BudgetItemViewModel>? BudgetItems { get; set; }

    public static BudgetViewModel From(Budget budget)
    {
        return new BudgetViewModel
        {
            Title = budget.Title,
            CompanyId = budget.CompanyId,
            CompanyTitle = budget.Company?.Title,
            BudgetItems = budget.BudgetItems?.Select(BudgetItemViewModel.From).ToList(),
        };
    }
}