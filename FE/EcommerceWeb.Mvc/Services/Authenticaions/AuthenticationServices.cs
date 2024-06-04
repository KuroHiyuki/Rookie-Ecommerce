using EcommerceWeb.Mvc.Models.Authentication;
using Newtonsoft.Json;

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

        public async Task<dynamic> RegisterAsync(RegisterRequest request)
        {
            request.FirstName = Guid.NewGuid().ToString();
            request.LastName = Guid.NewGuid().ToString();   
            var response = await _httpClient.PostAsJsonAsync("authentication/register", request);
            //response.EnsureSuccessStatusCode();
            return response;
        }
    }
}
