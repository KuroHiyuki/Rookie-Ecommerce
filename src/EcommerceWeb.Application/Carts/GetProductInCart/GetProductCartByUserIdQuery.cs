using EcommerceWeb.Application.Carts.Common.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceWeb.Application.Carts.GetProductInCart
{
    public record GetProductCartByUserIdQuery(string CartId) : IRequest<List<CartModelAppLayer>>
    {
    }
}
