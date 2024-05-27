using EcommerceWeb.Application.Carts.Common.Response;
using EcommerceWeb.Application.Common.Interface;
using EcommerceWeb.Application.Products.Common.Response;
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
        Task AddProductToCart(string userId, string productId, int quantity);
        Task<Cart> GetCartByUserId(string userId);
        Task UpdateProductQuantity(string CartId, string productId, int quantity);
        Task DeleteProductFromCart(string CartId, string productId);
        Task<List<CartModelAppLayer>> GetProductsInCart(string CartId);
        Task<CartDetail> GetCartDetail(string ProductId, string CartId);
    }
}
