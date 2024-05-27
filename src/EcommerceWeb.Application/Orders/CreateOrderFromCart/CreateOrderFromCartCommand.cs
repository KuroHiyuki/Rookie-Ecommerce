using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceWeb.Application.Orders.CreateOrderFromCart
{
    public record CreateOrderFromCartCommand(string UserId) : IRequest
    {
    }
}
