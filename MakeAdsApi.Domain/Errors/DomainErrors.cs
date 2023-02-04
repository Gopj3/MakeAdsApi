using ErrorOr;

namespace MakeAdsApi.Domain.Errors;

public static class DomainErrors
{
    public static class User
    {
        public static Error NotFound = Error.NotFound("User.NotFound", "User not found.");

        public static Error DuplicateEmail =>
            Error.Conflict("User.DuplicateEmail", "User with given email already exists.");

        public static Error InvalidCredentials => Error.NotFound("User.InvalidCredentials", "Invalid credentials");
    }

    public static class UserProfile
    {
        public static Error NotFound => Error.NotFound("UserProfile.NotFound", "User profile not found.");
    }

    public static class RetailDataProvider
    {
        public static Error NotFound => Error.NotFound("RetailDataProvider.NotFound", "Retail data provider not found.");
    }

    public static class Company
    {
        public static Error NotFound => Error.NotFound("Company.NotFound", "Company not found.");

        public static Error DuplicateCompanyExternalId =>
            Error.Conflict("Company.DuplicateCompanyExternalId", "Company with given external id exists");
    }

    public static class Office
    {
        public static Error NotFound => Error.NotFound("Office.NotFound", "Office not found.");

        public static Error DuplicateCompanyExternalId =>
            Error.Conflict("Office.DuplicateCompanyExternalId", "Office with given external id exists");
    }

    public static class Budget
    {
        public static Error NotFound => Error.NotFound("Budget.NotFound", "Budget not found.");
        
        public static Error DuplicateBudgetByType =>
            Error.Conflict("Budget.DuplicateBudgetByType",
                "Company can has Automatic or AfterSold budgets in one example");
    }

    public static class BudgetItem
    {
        public static Error NotFound => Error.NotFound("Budget item.NotFound", "Budget item not found.");

        public static Error DuplicateBudgetItemByType =>
            Error.Conflict("BudgetItem.DuplicateBudgetItemByType",
                "It is possible to create one budget item per type for budget");
    }
}