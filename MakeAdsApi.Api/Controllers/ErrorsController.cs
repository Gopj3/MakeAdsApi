using Microsoft.AspNetCore.Mvc;

namespace MakeAdsApi.Api.Controllers;

public class ErrorsController: ControllerBase
{
    [HttpGet("/error")]
    public IActionResult Error()
    {
        return Problem();
    }
}