using Microsoft.AspNetCore.Http;

namespace MakeAdsApi.Contracts.Admin.UserProfiles;

public record CreateEditUserProfileRequest(
    string FirstName,
    string LastName,
    string? Title,
    string? Phone,
    IFormFile? Avatar
);