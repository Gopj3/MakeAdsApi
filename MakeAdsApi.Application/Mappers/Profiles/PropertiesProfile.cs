using AutoMapper;
using MakeAdsApi.Application.Mappers.Extensions;
using MakeAdsApi.Application.Properties.Models;
using MakeAdsApi.Domain.Entities.Properties;

namespace MakeAdsApi.Application.Mappers.Profiles;

public class PropertiesProfile : Profile
{
    public PropertiesProfile()
    {
        CreateMap<Property, PropertyViewModel>().IgnoreUpdatedAt().CreatedAtToLongDateString();
    }
}