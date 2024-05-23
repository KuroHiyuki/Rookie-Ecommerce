using EcommerceWeb.Application.Categories.Common.Response;
using EcommerceWeb.Application.Products.Common.Response;
using ErrorOr;
using MediatR;
using Microsoft.AspNetCore.Http;


namespace EcommerceWeb.Application.Products.CreateProduct
{
    public class CreateProductCommand: IRequest
    {
        public string? Id { get; set; }
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public string? CategoryId { get; set; }
        public CategoryModelAppLayer Category { get; set; } = null!;
        public IFormFileCollection? Images { get; set; }
    }
}
