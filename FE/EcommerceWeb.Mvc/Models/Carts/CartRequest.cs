namespace EcommerceWeb.Mvc.Models.Carts
{
	public class CartRequest
	{
		public string? UserId { get; set; }
		public string? ProductId { get; set; }
		public int Quantity { get; set; }
	}
}
