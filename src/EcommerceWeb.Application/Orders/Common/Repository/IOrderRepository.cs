using EcommerceWeb.Application.Common.Interface;
using EcommerceWeb.Domain.Entities;

namespace EcommerceWeb.Application.Orders.Common.Repository
{
    public interface IOrderRepository : IBaseRepository<Order>
    {
        Task<Order> CreateOrderFromCart(string userId);
    }
}
