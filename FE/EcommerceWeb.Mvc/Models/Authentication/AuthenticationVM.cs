namespace EcommerceWeb.Mvc.Models.Authentication
{
    public record AuthenticationVM(
        string Id,
        string FirstName,
        string LastName,
        string Email,
        string AvatarURL,
        string Token,
        string NumberPhone,
        string Address
        );
}
