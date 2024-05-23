using EcommerceWeb.Application.Categories.Common.Repository;
using EcommerceWeb.Application.Common.Errors;
using EcommerceWeb.Application.Common.Interface;
using EcommerceWeb.Application.Common.Services;
using EcommerceWeb.Application.Products.Common.Interfaces;
using EcommerceWeb.Application.Users.Common.Repository;
using EcommerceWeb.Domain.Entities;

using MediatR;

namespace EcommerceWeb.Application.Products.CreateProduct
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand>
    {
        private readonly IProductRepository _productRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IFileStorage _fileStorageService;

        public CreateProductCommandHandler(
            IProductRepository productRepository,
            ICategoryRepository categoryRepository,
            IUnitOfWork unitOfWork,
            IFileStorage fileStorageService)
        {
            _productRepository = productRepository;
            _categoryRepository = categoryRepository;
            _unitOfWork = unitOfWork;
            _fileStorageService = fileStorageService;
        }

        public async Task Handle(CreateProductCommand command, CancellationToken cancellationToken)
        {
            var category = await _categoryRepository.GetByIdAsync(command.product.CategoryId!);

            if (category == null)
                throw new NotFoundException("Category not found");


            List<Image> productImages = new List<Image>();
            if (command.product.Images is not null && command.product.Images.Count() > 0)
            {

                productImages = await SaveProductImages(command);
            }

            var newProduct = new Product()
            {
                Name = command.product.Name,
                Description = command.product.Description,
                UnitPrice = command.product.Price,
                Inventory = command.product.Stock,
                Category = category,
                Images = productImages
            };
            _productRepository.Create(newProduct);
            await _unitOfWork.SaveAsync(cancellationToken);
        }
        private async Task<List<Image>> SaveProductImages(CreateProductCommand command)
        {
            List<Image> productImages = new List<Image>();
            List<Task<string>> imgSaveTasks = new();
            if (command.product.Images is not null)
            {
                foreach (var image in command.product.Images)
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
                    Url = task.Result
                };
                productImages.Add(productImage);
            });
            return productImages;
        }
    }
}
