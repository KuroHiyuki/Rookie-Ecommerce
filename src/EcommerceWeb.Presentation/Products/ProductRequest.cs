using Microsoft.AspNetCore.Http;

namespace EcommerceWeb.Presentation.Products
{
    public record ProductRequest(
        string Name,
        string Description,
        decimal Price,
        int Stock,
        string CategoryId,
        IFormFileCollection? Images);
    public record UpdateProductRequest(
        string Name,
        string Description,
        decimal UnitPrice,
        int Inventorry,
        string CategoryId,
        IFormFileCollection? Images
        );
}
