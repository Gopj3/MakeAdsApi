using System;
using MakeAdsApi.Application.Common.ViewModels;
using MakeAdsApi.Domain.Entities.Offices;

namespace MakeAdsApi.Application.Offices.Admin.Models;

public class OfficeViewModel: BaseViewModel
{
    public string Title { get; set; }
    public string ExternalId { get; set; }
    public Guid CompanyId { get; set; }

    public static OfficeViewModel From(Office office)
    {
        return new OfficeViewModel
        {
            Id = office.Id,
            Title = office.Title,
            ExternalId = office.ExternalId,
            CompanyId = office.CompanyId,
            CreatedAt = office.CreatedAt.ToLongDateString()
        };
    }
}