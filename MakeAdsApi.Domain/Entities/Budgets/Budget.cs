using System;
using System.Collections.Generic;
using MakeAdsApi.Domain.Entities.Companies;
using MakeAdsApi.Domain.Enums.Budgets;

namespace MakeAdsApi.Domain.Entities.Budgets;

public class Budget: BaseEntity
{
    public string Title { get; set; }
    public List<BudgetItem> BudgetItems { get; set; } = new();
    public BudgetType Type { get; set; }
    public Guid CompanyId { get; set; }
    public Company Company { get; set; }

    public Budget(Guid companyId, string title, BudgetType type)
    {
        Title = title;
        CompanyId = companyId;
        Type = type;
    }

    public void Update(string title, Guid companyId, BudgetType type)
    {
        Title = title;
        CompanyId = companyId;
        Type = type;
    }
}