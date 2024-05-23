using EcommerceWeb.Application.Carts.Common.Repositories;
using EcommerceWeb.Application.Common.Errors;
using EcommerceWeb.Application.Common.Interface;
using EcommerceWeb.Application.Products.Common.Interfaces;
using EcommerceWeb.Domain.Entities;
using ErrorOr;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace EcommerceWeb.Application.Carts.AddProduct
{
    public class AddProductToCartCommandHandler : IRequestHandler<AddProductToCartCommand, ErrorOr<FluentResults.Result>>
    {
        private readonly ICartRepository _cartRepository;
        private readonly IProductRepository _productRepository;
        private readonly IUnitOfWork _unitOfWork;

        public AddProductToCartCommandHandler(
            IProductRepository productRepository,
            ICartRepository cartCategory,
            IUnitOfWork unitOfWork)
        {
            _productRepository = productRepository;
            _cartRepository = cartCategory;
            _unitOfWork = unitOfWork;
        }
        public async Task<ErrorOr<FluentResults.Result>> Handle(AddProductToCartCommand command, CancellationToken cancellationToken)
        {
            var product = await _productRepository.GetByIdAsync(command.Id,cancellationToken);
            if (product == null)
            {
                throw new NotFoundException($"Product with id {command} not found!");
            }

            var userContext = "2"; // Assuming userContext is retrieved elsewhere

            var cart = await _cartRepository.GetCartByUserIdAsync(userContext);
            cart = cart ?? await CreateCartIfNotExists(command.Id, cancellationToken);

            AddProductToCart(cart, product, 2);

            await _unitOfWork.SaveAsync(cancellationToken);

            return FluentResults.Result.Ok();
        }

        private async Task<Cart> CreateCartIfNotExists(string userId, CancellationToken cancellationToken)
        {
            _cartRepository.Create(new Cart
            {
                Id = Guid.NewGuid().ToString(),
                UserId = userId
            });
            //await _sender.Send(new CreateCartCommand { UserId = userId }, cancellationToken);
            return (await _cartRepository.GetCartByUserIdAsync(userId))!;
        }

        private static void AddProductToCart(Cart cart, Product product, int quantity)
        {
            var cartDetail = cart.CartDetails.FirstOrDefault(cd => cd.Product!.Id == product.Id);
            if (cartDetail != null)
            {
                cartDetail.Quantity += quantity;
            }
            else
            {
                cart.CartDetails.Add(new CartDetail
                {
                    Product = product,
                    Quantity = quantity
                });
            }
        }
    }
}
