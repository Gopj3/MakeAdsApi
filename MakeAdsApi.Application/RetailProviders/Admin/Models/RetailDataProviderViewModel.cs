using MakeAdsApi.Application.Common.ViewModels;
using MakeAdsApi.Domain.Entities.RetailDataProviders;

namespace MakeAdsApi.Application.RetailProviders.Admin.Models;

public class RetailDataProviderViewModel: BaseViewModel
{
    public string Title { get; set; }
    public string? FetchPropertyDataUrl { get; set; }
    public string? UpdatePropertyDataUrl { get; set; }
    public string? FetchUserDataUrl { get; set; }
    public string? UpdateUserDataUrl { get; set; }
    
    public static RetailDataProviderViewModel? From(RetailDataProvider? entity)
    {
        if (entity is null)
            return null;
        
        return new RetailDataProviderViewModel
        {
            Id = entity.Id,
            Title = entity.Title,
            FetchPropertyDataUrl = entity.FetchPropertyDataUrl,
            UpdatePropertyDataUrl = entity.UpdatePropertyDataUrl,
            FetchUserDataUrl = entity.FetchUserDataUrl,
            UpdateUserDataUrl = entity.UpdateUserDataUrl,
            CreatedAt = entity.CreatedAt.ToLongDateString(),
        };
    }
}