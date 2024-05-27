using EcommerceWeb.Application.Common.Interface;
using EcommerceWeb.Domain.Common.Enum;
using EcommerceWeb.Domain.Entities;

namespace EcommerceWeb.Application.Orders.Common.Repository
{
    public interface IOrderRepository : IBaseRepository<Order>
    {
        Task<Order> CreateOrderFromCartAsync(string userId);
        Task UpdateOrderStatusAsync(string orderId, OrderStatus status);
        Task<Order> GetOrderByIdAsync(string orderId);
    }
}
