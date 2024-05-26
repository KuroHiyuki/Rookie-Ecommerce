using EcommerceWeb.Application.Common.Interface;
using EcommerceWeb.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceWeb.Application.Carts.Common.Repositories
{
    public interface ICartRepository : IBaseRepository<Cart>
    {
        Task<Cart?> GetCartByUserIdAsync(string userId);
        Task AddProductToCart(string userId, string productId, int quantity, CancellationToken cancellationToken = default);
    }
}
