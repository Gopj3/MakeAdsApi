using System;
using System.Collections.Generic;
using MakeAdsApi.Domain.Entities.Companies;

namespace MakeAdsApi.Domain.Entities.Budgets;

public class Budget: BaseEntity
{
    public string Title { get; set; }
    public List<BudgetItem> BudgetItems { get; set; } = new();
    public Guid CompanyId { get; set; }
    public Company Company { get; set; }

    public Budget(string title, Guid companyId)
    {
        Title = title;
        CompanyId = companyId;
    }

    public void Update(string title, Guid companyId)
    {
        Title = title;
        CompanyId = companyId;
    }
}