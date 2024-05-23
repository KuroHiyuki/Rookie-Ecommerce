using EcommerceWeb.Application.Categories.Common.Response;
using EcommerceWeb.Application.Common.Paginations;
using EcommerceWeb.Application.Products.Common.Interfaces;
using EcommerceWeb.Application.Products.Common.Response;
using EcommerceWeb.Domain.Entities;
using EcommerceWeb.Infrastructure.Common.BaseRepository;
using EcommerceWeb.Presentation.Persistences;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using EcommerceWeb.Infrastructure.Common.Service;
using Microsoft.Data.SqlClient;

namespace EcommerceWeb.Infrastructure.Products
{
    public class ProductRepository : BaseRepository<Product>, IProductRepository
    {
        public ProductRepository(EcommerceDbContext context) : base(context)
        {
        }
        public void SoftDelete(Product product)
        {
            _dbContext.Entry(product).Property("IsDeleted").CurrentValue = true;
        }
        public override async Task<Product?> GetByIdAsync(string id, CancellationToken cancellationToken = default(CancellationToken))
        {

            return await _dbContext.Products
                .Include(p => p.Category)
                .Include(p => p.Images)
                .FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public override async Task<IEnumerable<Product>> GetListAsync(Expression<Func<Product, bool>>? filter, CancellationToken cancellationToken = default)
        {
            return await _dbContext.Products
                .Include(p => p.Category)
                .Include(p => p.Images)
                .Where(filter ?? (e => true))
                .ToListAsync(cancellationToken);
        }

        public async Task<PaginatedList<ProductModelAppLayer>> GetProductsByCategoryNameAsync(string categoryName, string? searchTerm, string? sortOrder, string? sortColumn, int page, int pageSize, CancellationToken cancellationToken = default)
        {
            IQueryable<Product> productsQuery = _dbContext.Products
                .Where(p => p.Category!.Name == categoryName)
                .Include(p => p.Category)
                .Include(p => p.Images);

            productsQuery = QueryHelper.ApplyFiltersAndSorting(productsQuery, searchTerm, sortOrder, sortColumn);

            var productResponsesQuery = productsQuery.Select(p => new ProductModelAppLayer
            {
                Id = p.Id,
                Name = p.Name!,
                Description = p.Description!,
                Price = p.UnitPrice,
                Stock = p.Inventory,
                Category = new CategoryModelAppLayer
                {
                    Id = p.Category!.Id,
                    Name = p.Category.Name!
                },
                Images = (Microsoft.AspNetCore.Http.IFormFileCollection)p.Images.Select(i => i.Url).ToList()
            });

            return await PaginatedList<ProductModelAppLayer>.CreateAsync(productResponsesQuery, page, pageSize);
        }
        

        public async Task<PaginatedList<ProductModelAppLayer>> GetListProductPageAsync(PageQuery page, CancellationToken cancellationToken = default)
        {
            IQueryable<Product> productsQuery = _dbContext.Products
                .Include(p => p.Category)
                .Include(p => p.Images);
            productsQuery = QueryHelper.ApplyFiltersAndSorting(productsQuery, page.SearchTerm, page.SortOrder, page.SortColumn);

            var productResponsesQuery = productsQuery.Select(p => new ProductModelAppLayer
            {
                Id = p.Id,
                Name = p.Name!,
                Description = p.Description!,
                Price = p.UnitPrice,
                Stock = p.Inventory,
                Category = new CategoryModelAppLayer
                {
                    Id = p.Category!.Id,
                    Name = p.Category.Name!
                },
                Images = (Microsoft.AspNetCore.Http.IFormFileCollection)p.Images.Select(i => i.Url).ToList()
            });

            return await PaginatedList<ProductModelAppLayer>.CreateAsync(productResponsesQuery, page.Page, page.PageSize);
        }
        

    }
}
