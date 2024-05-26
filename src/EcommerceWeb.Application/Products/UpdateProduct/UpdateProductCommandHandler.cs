using EcommerceWeb.Application.Common.Errors;
using EcommerceWeb.Application.Common.Interface;
using EcommerceWeb.Application.Products.Common.Interfaces;
using EcommerceWeb.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceWeb.Application.Products.UpdateProduct
{
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand>
    {
        private readonly IProductRepository _productRepository;
        private readonly IUnitOfWork _unitOfWork;

        public UpdateProductCommandHandler(IUnitOfWork unitOfWork, IProductRepository productRepository)
        {
            _unitOfWork = unitOfWork;
            _productRepository = productRepository;
        }
        public async Task Handle(UpdateProductCommand command, CancellationToken cancellationToken)
        {
            var existingProduct = await _productRepository.GetByIdAsync(command.Id);

            if (existingProduct == null)
                throw new NotFoundException($"Product with id {command.Id} not found!");

            await _productRepository.RemoveProductImagesAsync(existingProduct);

            List<Image> productImages = new List<Image>();
            if (command.Images != null && command.Images.Count > 0)
            {
                productImages = await _productRepository.SaveProductImagesAsync(command.Images, command.Id);
            }

            UpdateProduct(existingProduct, command, productImages);

            await _productRepository.UpdateAsync(existingProduct);

            await _unitOfWork.SaveAsync(cancellationToken);
        }
        private static void UpdateProduct(Product existingProduct, UpdateProductCommand command, List<Image> productImages)
        {
            existingProduct.Name = command.Name;
            existingProduct.Description = command.Description;
            existingProduct.UnitPrice = command.UnitPrice;
            existingProduct.Inventory = command.Inventorry;
            existingProduct.Images = productImages;
        }
    }
}
