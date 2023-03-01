using AutoMapper;
using MakeAdsApi.Application.Mappers.Extensions;
using MakeAdsApi.Application.RetailProviders.Admin.Models;
using MakeAdsApi.Application.RetailProviders.Common.Models;
using MakeAdsApi.Domain.Entities.RetailDataProviders;

namespace MakeAdsApi.Application.Mappers.Profiles;

public class RetailDataProviderProfile : Profile
{
    public RetailDataProviderProfile()
    {
        CreateMap<RetailDataProvider, RetailDataProviderViewModel>().IgnoreUpdatedAt().CreatedAtToLongDateString();
        CreateMap<RetailDataPropertyApiResponse, RetailDataApiResponseViewModel>();
    }
}