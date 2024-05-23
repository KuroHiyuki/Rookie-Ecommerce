using EcommerceWeb.Application.Common.Interface;
using EcommerceWeb.Application.Common.Paginations;
using EcommerceWeb.Application.Products.Common.Response;
using EcommerceWeb.Domain.Entities;
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
        Task<PaginatedList<ProductModelAppLayer>> GetProductsByCategoryNameAsync(
        string categoryName,
        string? searchTerm,
        string? sortOrder,
        string? sortColumn,
        int page,
        int pageSize,
        CancellationToken cancellationToken = default);
        Task<PaginatedList<ProductModelAppLayer>> GetListProductPageAsync(PageQuery page, CancellationToken cancellationToken = default);
    }
}
