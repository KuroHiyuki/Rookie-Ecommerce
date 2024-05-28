using EcommerceWeb.Mvc.Models.Categories;

namespace EcommerceWeb.Mvc.Models.Products
{
    public class ProductVM
    {
		public string? Id { get; set; }
		public string Name { get; set; } = null!;
		public string Description { get; set; } = null!;
		public decimal Price { get; set; }
		public int Stock { get; set; }
		public string? CategoryId { get; set; }
		public CategoryVM Category { get; set; } = null!;
		public IEnumerable<string> Images { get; set; } = [];
	}
}
