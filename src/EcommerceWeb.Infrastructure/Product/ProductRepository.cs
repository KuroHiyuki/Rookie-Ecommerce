using EcommerceWeb.Application.Products.Common.Interfaces;
using EcommerceWeb.Application.Products.Common.Response;
using EcommerceWeb.Presentation.Persistences;
using FluentEmail.Core;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceWeb.Infrastructure.Product
{
    public class ProductRepository : IProductRepository
    {
        private readonly EcommerceDbContext _context;

        public ProductRepository(EcommerceDbContext context)
        {
            _context = context;
        }

        public Task<ProductResult> Create(ProductResult productModel)
        {
            throw new NotImplementedException();
        }

        public Task Delete(ProductResult productModel)
        {
            throw new NotImplementedException();
        }

        public Task<ProductResult> GetProductByAliasA(string slug)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ProductResult>> GetProductByCategory(int categoryId)
        {
            throw new NotImplementedException();
        }

        public ProductResult GetProductById(string productId)
        {
            throw new Exception();

        }

        public Task<IEnumerable<ProductResult>> GetProductByName(string productName)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ProductResult>> GetProductList()
        {
            throw new NotImplementedException();
        }

        public Task Update(ProductResult productModel)
        {
            throw new NotImplementedException();
        }
    }
}
