using ErrorOr;

namespace MakeAdsApi.Domain.Errors;

public static class DomainErrors
{
    public static class User
    {
        public static Error NotFound = Error.NotFound("User.NotFound", "User not found.");
        public static Error DuplicateEmail = Error.Conflict("User.DuplicateEmail", "User with given email already exists.");
        public static Error InvalidCredentials = Error.NotFound( "User.InvalidCredentials", "Invalid credentials");
    }
    
    public static class UserProfile
    {
        public static Error NotFound = Error.NotFound("UserProfile.NotFound", "User profile not found.");
    }

    public static class RetailDataProvider
    {
        public static Error NotFound = Error.NotFound("RetailDataProvider.NotFound", "Retail data provider not found.");
    }
}