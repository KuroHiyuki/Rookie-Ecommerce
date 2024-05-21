using EcommerceWeb.Application.Categories.Common.Repository;
using EcommerceWeb.Application.Common.Errors;
using EcommerceWeb.Application.Common.Interface;
using EcommerceWeb.Application.Products.Common.Interfaces;
using EcommerceWeb.Application.Users.Common.Repository;
using EcommerceWeb.Domain.Entities;
using ErrorOr;
using MediatR;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace EcommerceWeb.Application.Products.CreateProduct
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, ErrorOr<FluentResults.Result>>
    {
        private readonly IProductRepository _productRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IUserRepository _userRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CreateProductCommandHandler(
            IProductRepository productRepository,
            ICategoryRepository categoryRepository,
            IUnitOfWork unitOfWork,
            IUserRepository userRepository)
        {
            _productRepository = productRepository;
            _categoryRepository = categoryRepository;
            _unitOfWork = unitOfWork;
            _userRepository = userRepository;
        }

        public async Task<ErrorOr<FluentResults.Result>> Handle(CreateProductCommand command, CancellationToken cancellationToken)
        {
            var category = await _categoryRepository.GetByIdAsync(command.CategoryId);

            if (category == null)
                throw new NotFoundException("Category not found");

            var user = await _userRepository.GetUserByIdAsync(command.UserId);
            if (user == null)
                throw new NotFoundException("User not found");



            var newProduct = new Product()
            {
                Name = command.Name,
                Description = command.Description,
                UnitPrice = command.Price,
                Category = category,
            };
            _productRepository.Create(newProduct);
            await _unitOfWork.SaveAsync(cancellationToken);

            return FluentResults.Result.Ok();
        }
    }
}
