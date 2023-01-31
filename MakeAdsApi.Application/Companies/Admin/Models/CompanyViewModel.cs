using MakeAdsApi.Application.Common.ViewModels;
using MakeAdsApi.Application.RetailProviders.Admin.Models;
using MakeAdsApi.Domain.Entities.Companies;

namespace MakeAdsApi.Application.Companies.Admin.Models;

public class CompanyViewModel : BaseViewModel
{
    public string Title { get; set; }
    public string  ExternalId { get; set; }
    public RetailDataProviderViewModel? RetailDataProvider { get; set; }

    public static CompanyViewModel From(Company company)
    {
        return new CompanyViewModel
        {
            Id = company.Id,
            Title = company.Title,
            ExternalId = company.ExternalId,
            RetailDataProvider = RetailDataProviderViewModel.From(company.RetailDataProvider),
            CreatedAt = company.CreatedAt.ToLongDateString()
        };
    }
}
