using EcommerceWeb.Mvc.Models.Carts;
using EcommerceWeb.Mvc.Models.Reviews;
using Newtonsoft.Json;

namespace EcommerceWeb.Mvc.Services.Carts
{
	public class CartServices : ICartServices
	{
		private readonly HttpClient _httpClient;

		public CartServices(HttpClient httpClient)
		{
			_httpClient = httpClient;
		}

		public async Task AddToCartAsync(CartRequest request)
		{
			var response = await _httpClient.PostAsJsonAsync($"cart", request);
			response.EnsureSuccessStatusCode();
		}

		public async Task<dynamic> DeleteCartAsync(string CartId, string ProductId)
		{
            var response = await _httpClient.DeleteAsync($"cart/{CartId},{ProductId}");
            return response;
        }

		public async Task<List<CartVM>> GetProductInCartAsynce(string CartId, string userId)
		{
			var response = await _httpClient.GetAsync($"cart/{CartId},{userId}");
			if(response.IsSuccessStatusCode) 
			{
				string content = await response.Content.ReadAsStringAsync();
				var carts = JsonConvert.DeserializeObject<List<CartVM>>(content)!;
				return carts;
			}
			return new List<CartVM>();
		}

		public async Task<string> GetCardIdAsync(string UserId)
		{
			var response = await _httpClient.GetAsync($"cart/getID/{UserId}");

			string content = await response.Content.ReadAsStringAsync() as string;
			return content;
		}

		public async Task<dynamic> UpdateCartAsync(string CartId, CartRequest request)
		{
            var response = await _httpClient.PutAsJsonAsync($"cart/{CartId}", request);
            return response;
        }
	}
}
