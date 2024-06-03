using EcommerceWeb.Mvc.Models.Authentication;

namespace EcommerceWeb.Mvc.Services.Authenticaions
{
	public interface IAuthenticationServices
	{
		Task<AuthenticationVM> LoginAsync(string Email, string password);
		Task RegisterAsync(RegisterRequest request);
	}
}
