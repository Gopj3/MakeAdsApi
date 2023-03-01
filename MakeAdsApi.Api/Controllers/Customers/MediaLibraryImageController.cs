using MakeAdsApi.Api.Extensions;
using MakeAdsApi.Application.MediaLibraryFiles.Customers.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace MakeAdsApi.Api.Controllers.Customers;

public class MediaLibraryImageController : CustomersApiController
{
    private readonly IMediator _mediator;

    public MediaLibraryImageController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("properties/{id}/images")]
    public async Task<IActionResult> GetAllMediaLibraryImageAsync(string id)
    {
        if (!Guid.TryParse(id, out var propertyId))
        {
            return Problem("Invalid property id");
        }

        var result = await _mediator.Send(
            new GetAllMediaLibraryImagesQuery(
                propertyId,
                HttpContext.GetUserId()
            )
        );
        
        return result.Match<IActionResult>(Ok, BadRequest);
    }
}