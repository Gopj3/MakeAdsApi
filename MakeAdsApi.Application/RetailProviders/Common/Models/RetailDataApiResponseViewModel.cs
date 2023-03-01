using System.Collections.Generic;

namespace MakeAdsApi.Application.RetailProviders.Common.Models;

public class RetailDataApiResponseViewModel
{
    public string EmployeeEmail { get; set; }
    public string EmployeeTitle { get; set; }
    public string EmployeePhone { get; set; }
    public string EmployeeName { get; set; }
    public string EmployeeAvatar { get; set; }
    public string ExternalCompanyId { get; set; } 
    public string PropertyId { get; set; }
    public string PropertyLink { get; set; }
    public string PropertyAddress { get; set; }
    public string PropertyMarketingDate { get; set; } 
    public string PropertyEstateType { get; set; }
    public string PropertyPrice { get; set; }
    public string PropertyDescription { get; set; }
    public string BuildingOwnershipType { get; set; }
    public List<string> PropertyImages { get; set; }
    public string? PropertyPriceIndication { get; set; }
    public string PropertySquareMeters { get; set; }
    public string PropertyDebt { get; set; }

    public string PropertyViewDate { get; set; }

    public string OfficeCity { get; set; }

    public string OfficeTitle { get; set; }
        
    public string ExternalOfficeId { get; set; }

    public string SellerEmail { get; set; }

    public string BuildingType { get; set; }
}