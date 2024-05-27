using EcommerceWeb.Application.Orders.Common.Repository;
using EcommerceWeb.Domain.Common.Enum;
using EcommerceWeb.Domain.Entities;
using EcommerceWeb.Infrastructure.Common.BaseRepository;
using EcommerceWeb.Presentation.Persistences;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceWeb.Infrastructure.Orders
{
    public class OrderRepository : BaseRepository<Order>, IOrderRepository
    {
        public OrderRepository(EcommerceDbContext context) : base(context)
        {
        }

        public async Task<Order> CreateOrderFromCart(string userId)
        {
            var cart = await _dbContext.Carts
            .Include(c => c.CartDetails)
            .ThenInclude(cd => cd.Product)
            .FirstOrDefaultAsync(c => c.UserId == userId);

            if (cart == null || !cart.CartDetails.Any())
            {
                return new Order();
            }

            var order = new Order
            {
                Id = Guid.NewGuid().ToString(),
                UserId = userId,
                OrderDate = DateTime.UtcNow,
                TotalAmount = cart.CartDetails.Sum(cd => cd.Product!.UnitPrice * cd.Quantity),
                Status = OrderStatus.OrderPlaced,
                Details = cart.CartDetails.Select(cd => new OrderDetail
                {

                    ProductId = cd.ProductId,
                    Quantity = cd.Quantity,
                    UnitPrice = cd.Product!.UnitPrice
                }).ToList()
            };

            _dbContext.Orders.Add(order);
            _dbContext.CartDetails.RemoveRange(cart.CartDetails);
            await _dbContext.SaveChangesAsync();

            return order;
        }
    }
}
