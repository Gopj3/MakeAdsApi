using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace MakeAdsApi.Api.Controllers.Common;

public class RetailDataController: ApiController
{
    private readonly IMediator _Mediator;

    public RetailDataController(IMediator mediator)
    {
        _Mediator = mediator;
    }

    // [HttpGet("")]
    // public async Task<IActionResult> GetRetailDataByCompanyPropertyIdsAsync(
    //     [FromQuery] string companyId,
    //     [FromQuery] string propertyId
    // )
    // {
    //     
    // }
}