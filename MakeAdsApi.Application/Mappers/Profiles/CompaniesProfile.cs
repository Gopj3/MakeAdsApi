using AutoMapper;
using MakeAdsApi.Application.Companies.Admin.Models;
using MakeAdsApi.Application.Mappers.Extensions;
using MakeAdsApi.Domain.Entities.Companies;

namespace MakeAdsApi.Application.Mappers.Profiles;

public class CompaniesProfile : Profile
{
    public CompaniesProfile()
    {
        CreateMap<Company, CompanyViewModel>().IgnoreUpdatedAt().CreatedAtToLongDateString();
    }
}