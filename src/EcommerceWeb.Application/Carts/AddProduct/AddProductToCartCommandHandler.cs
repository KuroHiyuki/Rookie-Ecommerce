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
    public class AddProductToCartCommandHandler : IRequestHandler<AddProductToCartCommand>
    {
        private readonly ICartRepository _cartRepository;
        private readonly IUnitOfWork _unitOfWork;

        public AddProductToCartCommandHandler(
            ICartRepository cartCategory,
            IUnitOfWork unitOfWork)
        {
            _cartRepository = cartCategory;
            _unitOfWork = unitOfWork;
        }
        public async Task Handle(AddProductToCartCommand command, CancellationToken cancellationToken)
        {
            var cart = await _cartRepository.GetCartByUserId(command.UserId);
            var cartDetail = await _cartRepository.GetCartDetail(command.ProductId, cart.Id!);
            if (cartDetail is null)
            {
                await _cartRepository.AddProductToCart(command.UserId, command.ProductId, command.Quantity);
                
            }
            else
            {
                cartDetail.Quantity = command.Quantity + cartDetail.Quantity;
                
            }
            await _unitOfWork.SaveAsync(cancellationToken);

        }

    }
}
