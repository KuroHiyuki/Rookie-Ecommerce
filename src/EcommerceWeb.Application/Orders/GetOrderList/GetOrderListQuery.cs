using EcommerceWeb.Application.Orders.Common.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceWeb.Application.Orders.GetOrderList
{
    public record GetOrderListQuery : IRequest<OrderModelAppLayer>
    {
    }
}
