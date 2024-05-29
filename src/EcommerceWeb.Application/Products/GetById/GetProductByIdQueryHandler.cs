
using EcommerceWeb.Application.Common.Errors;
using EcommerceWeb.Application.Common.Interface;
using EcommerceWeb.Application.Products.Common.Interfaces;
using EcommerceWeb.Application.Products.Common.Response;
using ErrorOr;
using FluentResults;
using MediatR;

namespace EcommerceWeb.Application.Products.GetById
{
    public class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQuery, ProductModelAppLayer>
    {
        private readonly IProductRepository _productRepository;

        public GetProductByIdQueryHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<ProductModelAppLayer> Handle(GetProductByIdQuery query, CancellationToken cancellationToken)
        {
            var product = await _productRepository.GetProdcutByIdAsync(query.Id);
            if(product is null )
            {
                throw new Exception($"Not Found Product Id : {query.Id}");
            }    
            var result = new ProductModelAppLayer
            {
                Id = product!.Id,
                Name = product!.Name!,
                Price = product.UnitPrice,
                Stock = product.Inventory,
                CategoryId = product.CategoryId,
                Description = product.Description!,
                Images = product.Images!.Select(u => u.Url).ToList(),
                Category = new Categories.Common.Response.CategoryModelAppLayer
                {
                    Id = product.CategoryId,
                    Name = product.Name,
                    Description = product.Description
                }
            };
            return result;
        }
    }
}
