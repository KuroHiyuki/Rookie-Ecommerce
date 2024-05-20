using ErrorOr;

namespace EcommerceWeb.Application.Authentication.Errors
{
    public static partial class Errors
    {
        public static class UserAuthentication
        {
            public static Error InvalidCredentials => Error.Validation(
                code: "Authentication.InvalidCredentials",
                description: "Invalid Credentitals.");
        }
    }
}
