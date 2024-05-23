﻿using EcommerceWeb.Application.Categories.Common.Repository;
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
        private readonly IFileStorage _fileStorageService;

        public CreateProductCommandHandler(
            IProductRepository productRepository,
            IUnitOfWork unitOfWork,
            IFileStorage fileStorageService)
        {
            _productRepository = productRepository;
            _unitOfWork = unitOfWork;
            _fileStorageService = fileStorageService;
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

            List<Image> productImages = new List<Image>();
            if (command.Images is not null && command.Images.Count() > 0)
            {
                productImages = await SaveProductImages(command);
            }

            
            await _productRepository.CreateProductAsync(newProduct,productImages);
            await _unitOfWork.SaveAsync(cancellationToken);
        }
        private async Task<List<Image>> SaveProductImages(CreateProductCommand command)
        {
            List<Image> productImages = new List<Image>();
            List<Task<string>> imgSaveTasks = new();
            if (command.Images is not null)
            {
                foreach (var image in command.Images)
                {
                    // Save image to storage and get the path
                    imgSaveTasks.Add(_fileStorageService.SaveFileAsync(image));
                }
            }

            await Task.WhenAll(imgSaveTasks);

            imgSaveTasks.ForEach(task =>
            {
                var productImage = new Image()
                {
                    Id= Guid.NewGuid().ToString(),
                    Url = task.Result
                };
                productImages.Add(productImage);
            });
            return productImages;
        }
    }
}
