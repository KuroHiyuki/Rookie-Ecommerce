using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceWeb.Application.Carts.RemoveProductInCart
{
    public record RemoveProductInCartCommand(string cartId, string ProductId) : IRequest
    {
    }
}
