using EcommerceWeb.Mvc.Models.Authentication;

namespace EcommerceWeb.Mvc.Services.Authenticaions
{
	public interface IAuthenticationServices
	{
		Task<dynamic> LoginAsync(LoginRequest request);
		Task<dynamic> RegisterAsync(RegisterRequest request);
	}
}
