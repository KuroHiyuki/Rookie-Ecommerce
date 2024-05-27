using EcommerceWeb.Application.Carts.Common.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceWeb.Application.Carts.GetCartIdByUser
{
    public class GetCartidByUserIdQueryHandler : IRequestHandler<GetCartIdByUserIdQuery, string>
    {
        private readonly ICartRepository _cartRepository;

        public GetCartidByUserIdQueryHandler(ICartRepository cartRepository)
        {
            _cartRepository = cartRepository;
        }

        public async Task<string> Handle(GetCartIdByUserIdQuery request, CancellationToken cancellationToken)
        {
            var cart =  await _cartRepository.GetCartByUserIdAsync(request.UserId);
            if(cart!.Id is null)
            {
                return $"User Id {request.UserId} haven't add a product to the cart yet";
            }
            return cart.Id;
        }
    }
}
