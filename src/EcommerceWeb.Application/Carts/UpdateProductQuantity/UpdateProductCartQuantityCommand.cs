using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceWeb.Application.Carts.UpdateProductQuantity
{
    public record UpdateProductCartQuantityCommand(string CartId, string ProductId, int Quantity) : IRequest
    {
    }
}
