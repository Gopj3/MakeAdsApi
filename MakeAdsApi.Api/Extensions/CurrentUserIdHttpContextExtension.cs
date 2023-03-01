using System.Security.Claims;

namespace MakeAdsApi.Api.Extensions;

public static class CurrentUserIdHttpContextExtension
{
    public static Guid GetUserId(this HttpContext httpContext)
    {
        var claim = httpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        if (claim is null)
            throw new UnauthorizedAccessException("Unauthorized action");

        if (Guid.TryParse(claim, out var userId))
            return userId;
        
        throw new UnauthorizedAccessException("Unauthorized action");
    }
}