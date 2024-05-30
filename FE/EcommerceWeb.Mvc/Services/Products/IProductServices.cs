using EcommerceWeb.Mvc.Models.Products;
using EcommerceWeb.Presentation.Common;


namespace EcommerceWeb.Mvc.Services.Products
{
    public interface IProductServices
    {
        Task<Paginated<ProductVM>> GetProductsAsync(PageQuery page = default!);
        Task<Paginated<ProductVM>> GetProductsByCategoryNameAsync(string categoryName, PageQuery page = default!);
        Task<ProductVM?> GetProductByIdAsync(string id);
    }
}
