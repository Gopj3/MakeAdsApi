using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace MakeAdsApi.Application.RetailProviders.Common.Models;

public class RetailDataPropertyApiResponse
{
    [JsonPropertyName("ansatte1_email")]
    public string EmployeeEmail { get; set; }
    
    [JsonPropertyName("ansatte1_tittel")]
    public string EmployeeTitle { get; set; }

    [JsonPropertyName("ansatte1_mobiltelefon")]
    public string EmployeePhone { get; set; }
    
    [JsonPropertyName("ansatte1_navn")]
    public string EmployeeName { get; set; }
    
    [JsonPropertyName("ansatte1_urloriginalbildelink")]
    public string EmployeeAvatar { get; set; }

    [JsonPropertyName("databasenummer")]
    public string ExternalCompanyId { get; set; } 
    
    [JsonPropertyName("oppdragsnummer")]
    public string PropertyId { get; set; }
    
    [JsonPropertyName("httplinkoppdrag")]
    public string PropertyLink { get; set; }
    
    [JsonPropertyName("adresse")]
    public string PropertyAddress { get; set; }
    
    [JsonPropertyName("markedsforingsdato")]
    public string PropertyMarketingDate { get; set; } 
    
    [JsonPropertyName("type_eiendomstyper")]
    public string PropertyEstateType { get; set; }

    [JsonPropertyName("totalkostnadsomtall")]
    public string PropertyPrice { get; set; }

    [JsonPropertyName("overskrift")]
    public string PropertyDescription { get; set; }

    [JsonPropertyName("type_eierformbygninger")]
    public string BuildingOwnershipType { get; set; }
    
    [JsonPropertyName("bigImages")]
    public List<string> PropertyImages { get; set; }

    [JsonPropertyName("prisantydning")]
    public string? PropertyPriceIndication { get; set; }
    
    [JsonPropertyName("bruksareal")]
    public string PropertySquareMeters { get; set; }

    [JsonPropertyName("andelfellesgjeld")]
    public string PropertyDebt { get; set; }

    [JsonPropertyName("visning_1_fra")]
    public string PropertyViewDate { get; set; }

    [JsonPropertyName("poststed")]
    public string OfficeCity { get; set; }

    [JsonPropertyName("avdeling_navn")]
    public string OfficeTitle { get; set; }
        
    [JsonPropertyName("avdeling_id")]
    public string ExternalOfficeId { get; set; }

    [JsonPropertyName("selger1_email")]
    public string SellerEmail { get; set; }

    [JsonPropertyName("type_oppdrag")]
    public string BuildingType { get; set; }
}