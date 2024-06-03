using EcommerceWeb.Mvc.Models.Authentication;

namespace EcommerceWeb.Mvc.Services.Authenticaions
{
    public class AuthenticationServices : IAuthenticationServices
	{
        private readonly HttpClient _httpClient;

        public AuthenticationServices(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public Task<AuthenticationVM> LoginAsync(string Email, string password)
        {
            throw new NotImplementedException();
        }

        public async Task RegisterAsync(RegisterRequest request)
        {

            var response = await _httpClient.PostAsJsonAsync("authentication/register", request);
            response.EnsureSuccessStatusCode();
        }
    }
}
