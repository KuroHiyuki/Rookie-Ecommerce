using EcommerceWeb.Mvc.Models.Products;
using EcommerceWeb.Presentation.Common;


namespace EcommerceWeb.Mvc.Services.Products
{
    public interface IProductServices
    {
        Task<Paginated<ProductVM>> GetProductsAsync();
        Task<Paginated<ProductVM>> GetProductsByCategoryNameAsync(string categoryName);
        Task<ProductVM?> GetProductByIdAsync(string id);
    }
}
