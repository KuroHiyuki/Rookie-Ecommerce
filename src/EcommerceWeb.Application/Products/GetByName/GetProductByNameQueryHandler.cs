using EcommerceWeb.Application.Products.Common.Interfaces;
using EcommerceWeb.Application.Products.Common.Response;
using EcommerceWeb.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace EcommerceWeb.Application.Products.GetByName
{
    public class GetProductByNameQueryHandler : IRequestHandler<GetProductByNameQuery, IEnumerable<ProductModelAppLayer>>
    {
        private readonly IProductRepository _productRepository;

        public GetProductByNameQueryHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<IEnumerable<ProductModelAppLayer>> Handle(GetProductByNameQuery query, CancellationToken cancellationToken)
        {
            var products = await _productRepository.GetListAsync(x => x.Category!.Name!.Contains(query.CategoryName, StringComparison.OrdinalIgnoreCase));

            return products.Select(p => new ProductModelAppLayer
            {
                Id = p.Id!,
                Name = p.Name!,
                Description = p.Description!,
                Price = p.UnitPrice,
                Stock = p.Inventory,
                Category = new Categories.Common.Response.CategoryModelAppLayer
                {
                    Id = p.Category!.Id!,
                    Name = p.Category.Name!
                },
            });
        }
    }
}
