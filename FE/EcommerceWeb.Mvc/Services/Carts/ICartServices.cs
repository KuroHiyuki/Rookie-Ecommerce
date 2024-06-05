using EcommerceWeb.Mvc.Models.Carts;

namespace EcommerceWeb.Mvc.Services.Carts
{
	public interface ICartServices
	{
		Task<string> GetCardIdAsync(string UserId);
		Task<List<CartVM>> GetProductInCartAsynce(string CartId, string UserId);
		Task AddToCartAsync(CartRequest request);
		Task<dynamic> UpdateCartAsync(string CartId, CartRequest request);
		Task<dynamic> DeleteCartAsync(string CartId, string ProductId);
	}
}
