using EcommerceWeb.Application.Carts.Common.Repositories;
using EcommerceWeb.Application.Common.Interface;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceWeb.Application.Carts.RemoveProductInCart
{
    public class RemoveProductInCartCommandHandler : IRequestHandler<RemoveProductInCartCommand>
    {
        private readonly ICartRepository _cartRepository;
        private readonly IUnitOfWork _unitOfWork;
        public RemoveProductInCartCommandHandler(ICartRepository cartRepository, IUnitOfWork unitOfWork)
        {
            _cartRepository = cartRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(RemoveProductInCartCommand request, CancellationToken cancellationToken)
        {
            await _cartRepository.DeleteProductFromCart(request.CartId, request.ProductId);
            await _unitOfWork.SaveAsync(cancellationToken);
        }
    }
}
