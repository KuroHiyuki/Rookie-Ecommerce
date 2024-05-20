using EcommerceWeb.Mvc.Models;

namespace EcommerceWeb.Mvc.Services.Products
{
    public interface IProductServices
    {
        Task<List<ProductVM>> GetProductsAsync();
        Task<List<ProductVM>> GetProductsByCategoryNameAsync(string categoryName);
        Task<ProductVM?> GetProductByIdAsync(int id);
    }
}
