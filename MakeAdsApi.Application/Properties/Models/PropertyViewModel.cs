using MakeAdsApi.Application.Common.ViewModels;
using MakeAdsApi.Domain.Entities.Properties;

namespace MakeAdsApi.Application.Properties.Models;

public class PropertyViewModel: BaseViewModel
{
    public string PropertyId { get; set; }
    public bool IsSold { get; set; }
    public string Address { get; set; }
}