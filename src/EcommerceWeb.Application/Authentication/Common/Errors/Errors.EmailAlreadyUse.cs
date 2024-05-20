using ErrorOr;

namespace EcommerceWeb.Application.Authentication.Errors
{
    public static partial class Errors
    {
        public static class EmailAlreadyUse
        {
            public static Error EmailExists => Error.Conflict(
                code: "User.EmailExists.",
                description: "Email is already in use.");
        }
    }
}
