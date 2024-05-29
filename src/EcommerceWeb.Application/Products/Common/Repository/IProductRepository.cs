using EcommerceWeb.Application.Common.Interface;
using EcommerceWeb.Application.Common.Services.Paginations;
using EcommerceWeb.Application.Products.Common.Response;
using EcommerceWeb.Application.Products.CreateProduct;
using EcommerceWeb.Application.Products.UpdateProduct;
using EcommerceWeb.Domain.Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceWeb.Application.Products.Common.Interfaces
{
    public interface IProductRepository : IBaseRepository<Product>
    {
        void SoftDelete(Product product);
        Task<Paginated<ProductModelAppLayer>> GetProductsByCategoryNameAsync(
        string categoryName,
        string? searchTerm,
        string? sortOrder,
        string? sortColumn,
        int page,
        int pageSize,
        CancellationToken cancellationToken = default);
        Task<Paginated<ProductModelAppLayer>> GetListProductPageAsync(PageQuery page, CancellationToken cancellationToken = default);
        Task UpdateAsync(Product product);
        Task RemoveProductImagesAsync(Product product);
        Task<List<Image>> SaveProductImagesAsync(IFormFileCollection formFiles, string Id);
        Task CreateProductAsync(ProductModelAppLayer model, List<Image> images);
        Task<Product> GetProdcutByIdAsync(string id);
    }
}
