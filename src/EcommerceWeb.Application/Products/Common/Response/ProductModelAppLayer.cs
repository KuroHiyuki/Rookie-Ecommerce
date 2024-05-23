using EcommerceWeb.Application.Categories.Common.Response;
using Microsoft.AspNetCore.Http;

namespace EcommerceWeb.Application.Products.Common.Response
{
    public class ProductModelAppLayer
    {
        public string? Id { get; set; }
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public string? CategoryId { get; set; }
        public CategoryModelAppLayer Category { get; set; } = null!;
        public IEnumerable<string>? Images { get; set; }
    }
}
