using EcommerceWeb.Application.Products.Common.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceWeb.Application.Products.Common.Interfaces
{
    public interface IProductRepository
    {
        Task<IEnumerable<ProductResult>> GetProductList();
        ProductResult GetProductById(string productId);
        Task<ProductResult> GetProductByAliasA(string slug);
        Task<IEnumerable<ProductResult>> GetProductByName(string productName);
        Task<IEnumerable<ProductResult>> GetProductByCategory(int categoryId);
        Task<ProductResult> Create(ProductResult productModel);
        Task Update(ProductResult productModel);
        Task Delete(ProductResult productModel);
    }
}
