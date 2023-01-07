using ErrorOr;

namespace MakeAdsApi.Domain.Errors;

public static class DomainErrors
{
    public static class User
    {
        const int InvalidCredentialsCodeType = 10;
        
        public static Error NotFound = Error.NotFound("User.NotFound", "User not found.");
        public static Error DuplicateEmail = Error.Conflict("User.DuplicateEmail", "User with given email already exists.");
        public static Error InvalidCredentials = Error.Custom(InvalidCredentialsCodeType, "User.InvalidCredentials", "Invalid credentials");
    }
}