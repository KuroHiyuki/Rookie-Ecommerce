using EcommerceWeb.Application.Categories.Common.Response;
using EcommerceWeb.Application.Products.Common.Interfaces;
using EcommerceWeb.Application.Products.Common.Response;
using EcommerceWeb.Domain.Entities;
using EcommerceWeb.Infrastructure.Common.BaseRepository;
using EcommerceWeb.Presentation.Persistences;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using EcommerceWeb.Infrastructure.Common.Service;
using Microsoft.Data.SqlClient;
using EcommerceWeb.Application.Common.Services.Paginations;
using EcommerceWeb.Application.Common.Services;
using EcommerceWeb.Application.Products.CreateProduct;
using Microsoft.AspNetCore.Http;

namespace EcommerceWeb.Infrastructure.Products
{
    public class ProductRepository : BaseRepository<Product>, IProductRepository
    {
        private readonly IFileStorage _fileStorage;
        public ProductRepository(EcommerceDbContext context, IFileStorage fileStorage) : base(context)
        {
            _fileStorage = fileStorage;
        }
        public void SoftDelete(Product product)
        {
            _dbContext.Entry(product).Property("IsDeleted").CurrentValue = true;
        }
        public override async Task<Product?> GetByIdAsync(string id, CancellationToken cancellationToken = default)
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

        public async Task<Paginated<ProductModelAppLayer>> GetProductsByCategoryNameAsync(string categoryName, string? searchTerm, string? sortOrder, string? sortColumn, int page, int pageSize, CancellationToken cancellationToken = default)
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
                Images = p.Images.Select(i => i.Url).ToList()
            });

            return await Paginated<ProductModelAppLayer>.CreateAsync(productResponsesQuery, page, pageSize);
        }
        

        public async Task<Paginated<ProductModelAppLayer>> GetListProductPageAsync(PageQuery page, CancellationToken cancellationToken = default)
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
                CategoryId = p.CategoryId,
                CreatedAt = p.CreatedAt,
                Category = new CategoryModelAppLayer
                {
                    Id = p.Category!.Id,
                    Name = p.Category.Name!,
                    Description = p.Description!
                },
                Images =p.Images.Select(i => i.Url).ToList()
            });

            return await Paginated<ProductModelAppLayer>.CreateAsync(productResponsesQuery, page.Page, page.PageSize);
        }

        public async Task UpdateAsync(Product product)
        {
            _dbContext.Products.Update(product);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<List<Image>> SaveProductImagesAsync(IFormFileCollection formFiles, string Id)
        {
            List<Image> productImages = [];
            List<Task<string>> imgSaveTasks = [];
            foreach (var image in formFiles)
            {
                imgSaveTasks.Add(_fileStorage.SaveFileAsync(image));
            }

            await Task.WhenAll(imgSaveTasks);

            imgSaveTasks.ForEach(task =>
            {
                var productImage = new Image()
                {
                    Id = Guid.NewGuid().ToString(),
                    Url = task.Result,
                    ProductId = Id
                };
                productImages.Add(productImage);
            });

            return productImages;
        }

        public async Task CreateProductAsync(ProductModelAppLayer model, List<Image> images)
        {
            if(await _dbContext.Categories.FindAsync(model.CategoryId) is null )
            {
                throw new Exception($"Invalid Category ID: {model.CategoryId}");
            }
            var product = new Product()
            {
                Id = Guid.NewGuid().ToString(),
                Name = model.Name,
                Description = model.Description,
                UnitPrice = model.Price,
                Inventory = model.Stock,
                CategoryId = model.CategoryId,
                ImageURL = images[0].Url,
                CreatedAt = DateTime.Now
            };
            _dbContext.Products.Add(product);
            _dbContext.SaveChanges();
            foreach(var image in images)
            {
                image.ProductId = product.Id;
                _dbContext.Images.Add(image);
            }
            await _dbContext.SaveChangesAsync();
        }

        public async Task RemoveProductImagesAsync(Product product)
        {
            List<Task> imgDeleteTasks = [];
            foreach (var image in product.Images)
            {
                imgDeleteTasks.Add(_fileStorage.DeleteFileAsync(image.Url));
            }
            await Task.WhenAll(imgDeleteTasks);
            product.Images.Clear();
        }

        public async Task<Product> GetProdcutByIdAsync(string id)
        {
            var product = await _dbContext.Products
                            .Include(c => c.Category)
                            .Include(i => i.Images)
                            .FirstOrDefaultAsync(p =>  p.Id == id);
            if(product is null )
            {
                throw new Exception($"Not Found Product Id: {id}");
            }
            return product;
        }
    }
}
