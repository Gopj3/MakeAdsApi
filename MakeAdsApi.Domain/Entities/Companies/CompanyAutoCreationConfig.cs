using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MakeAdsApi.Domain.Enums;

namespace MakeAdsApi.Domain.Entities.Companies;

public class CompanyAutoCreationConfig: BaseEntity
{ 
    public string AdTitle { get; set; }
    public string AdMessage { get; set; }
    public string AdCaption { get; set; }
    public string AdDescription { get; set; }
    public int RadiusInKm { get; set; }
    public List<AvailableSocialMedias> AvailableSocialMedias { get; set; }
    public AutoCreationConfigType Type { get; set; }
    public Guid CompanyId { get; set; }
    public Company Company { get; set; }
}