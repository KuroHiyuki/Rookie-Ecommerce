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

		public Task AddToCartAsync(CartRequest request)
		{
			throw new NotImplementedException();
		}

		public Task<dynamic> DeleteCartAsync(string CartId, string ProductId)
		{
			throw new NotImplementedException();
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

			response.EnsureSuccessStatusCode();

			string content = await response.Content.ReadAsStringAsync() as string;
			return content;
		}

		public Task<dynamic> UpdateCartAsync(string CartId, CartRequest request)
		{
			throw new NotImplementedException();
		}
	}
}
