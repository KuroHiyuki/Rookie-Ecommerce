using EcommerceWeb.Domain.Common.Enum;
using MediatR;

namespace EcommerceWeb.Application.Orders.UpdateOrderStatus
{
    public record UpdateOrderStatusCommand(string OrderId, OrderStatus Status) : IRequest
    {
    }
}
