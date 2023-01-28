using MakeAdsApi.Application.Common.ViewModels;
using MakeAdsApi.Domain.Entities.RetailDataProviders;

namespace MakeAdsApi.Application.RetailProviders.Admin.Models;

public class RetailDataProviderViewModel: BaseViewModel
{
    public string? FetchPropertyDataUrl { get; set; }
    public string? UpdatePropertyDataUrl { get; set; }
    public string? FetchUserDataUrl { get; set; }
    public string? UpdateUserDataUrl { get; set; }
    
    public static RetailDataProviderViewModel From(RetailDataProvider entity)
    {
        return new RetailDataProviderViewModel
        {
            Id = entity.Id,
            FetchPropertyDataUrl = entity.FetchPropertyDataUrl,
            UpdatePropertyDataUrl = entity.UpdatePropertyDataUrl,
            FetchUserDataUrl = entity.FetchUserDataUrl,
            UpdateUserDataUrl = entity.UpdateUserDataUrl
        };
    }
}