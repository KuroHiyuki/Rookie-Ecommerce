using Microsoft.AspNetCore.Http;

namespace EcommerceWeb.Presentation.Products
{
    public record ProductRequest(
        string Name,
        string Description,
        decimal UnitPrice,
        int Inventory,
        string CategoryId,
        string VendorId,
        string ImageURl);
    public record UpdateProductRequest(
        string Name,
        string Description,
        decimal UnitPrice,
        int Inventorry,
        string CategoryId
        );
}
