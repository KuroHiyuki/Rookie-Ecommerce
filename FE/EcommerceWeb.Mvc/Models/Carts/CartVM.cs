namespace EcommerceWeb.Mvc.Models.Carts
{
    public class CartVM
    {
        public string? ProductId { get; set; }
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public string? Images { get; set; }
    }
}
