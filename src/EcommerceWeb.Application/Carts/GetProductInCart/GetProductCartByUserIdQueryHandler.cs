using EcommerceWeb.Application.Carts.Common.Repositories;
using EcommerceWeb.Application.Carts.Common.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceWeb.Application.Carts.GetProductInCart
{
    public class GetProductCartByUserIdQueryHandler : IRequestHandler<GetProductCartByUserIdQuery, List<CartModelAppLayer>>
    {
        private readonly ICartRepository _cartRepository;

        public GetProductCartByUserIdQueryHandler(ICartRepository cartRepository)
        {
            _cartRepository = cartRepository;
        }

        public async Task<List<CartModelAppLayer>> Handle(GetProductCartByUserIdQuery request, CancellationToken cancellationToken)
        {
            return await _cartRepository.GetProductsInCart(request.CartId);
        }
    }
}
