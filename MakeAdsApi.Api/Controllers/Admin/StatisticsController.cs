using MakeAdsApi.Application.Statistics.Admin.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace MakeAdsApi.Api.Controllers.Admin;

public class StatisticsController : AdminApiController
{
    private readonly IMediator _mediator;

    public StatisticsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("")]
    public async Task<IActionResult> GetStatistics()
    {
        var result = await _mediator.Send(new GetStatisticsQuery());
        
        return result.Match(
            res => Ok(res),
            err => Problem(err)
        );
    }
}