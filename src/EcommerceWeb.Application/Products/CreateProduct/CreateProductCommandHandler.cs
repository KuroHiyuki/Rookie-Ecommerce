using EcommerceWeb.Application.Categories.Common.Repository;
using EcommerceWeb.Application.Common.Errors;
using EcommerceWeb.Application.Common.Interface;
using EcommerceWeb.Application.Common.Services;
using EcommerceWeb.Application.Products.Common.Interfaces;
using EcommerceWeb.Application.Users.Common.Repository;
using EcommerceWeb.Domain.Entities;

using MediatR;
using Microsoft.VisualBasic;

namespace EcommerceWeb.Application.Products.CreateProduct
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand>
    {
        private readonly IProductRepository _productRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CreateProductCommandHandler(
            IProductRepository productRepository,
            IUnitOfWork unitOfWork)
        {
            _productRepository = productRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(CreateProductCommand command, CancellationToken cancellationToken)
        {
            //throw new NotFoundException("Category not found");

            var newProduct = new Common.Response.ProductModelAppLayer
            {
                Id = Guid.NewGuid().ToString(),
                Name = command.Name,
                Description = command.Description,
                Price = command.Price,
                Stock = command.Stock,
                CategoryId = command.CategoryId,
            };

            List<Image> productImages = [];
            if (command.Images is not null && command.Images.Count > 0)
            {
                productImages = await _productRepository.SaveProductImagesAsync(command.Images, newProduct.Id);
            }

            
            await _productRepository.CreateProductAsync(newProduct,productImages);
            await _unitOfWork.SaveAsync(cancellationToken);
        }
    }
}
