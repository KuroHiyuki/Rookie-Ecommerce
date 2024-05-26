using EcommerceWeb.Application.Carts.Common.Repositories;
using EcommerceWeb.Domain.Entities;
using EcommerceWeb.Infrastructure.Common.BaseRepository;
using EcommerceWeb.Presentation.Persistences;
using Microsoft.EntityFrameworkCore;

namespace EcommerceWeb.Infrastructure.Carts
{
    public class CartRepository : BaseRepository<Cart>, ICartRepository
    {
        public CartRepository(EcommerceDbContext context) : base(context)
        {
        }

        public async Task AddProductToCart(string userId, string productId, int quantity, CancellationToken cancellationToken = default)
        {
            var cart = await _dbContext.Carts
             .Include(c => c.CartDetails)
             .FirstOrDefaultAsync(c => c.UserId == userId && c.CartDetails.Any());

            if (cart == null)
            {
                cart = new Cart
                {
                    Id = Guid.NewGuid().ToString(),
                    UserId = userId,
                    CreatedAt = DateTime.UtcNow,
                    CartDetails = new List<CartDetail>()
                };
                _dbContext.Carts.Add(cart);
            }

            var cartDetail = cart.CartDetails.FirstOrDefault(cd => cd.ProductId == productId);
            if (cartDetail != null)
            {
                cartDetail.Quantity += quantity;
            }
            else
            {
                cartDetail = new CartDetail
                {
                    Id = Guid.NewGuid().ToString(),
                    ProductId = productId,
                    Quantity = quantity,
                    Cart = cart
                };
                cart.CartDetails.Add(cartDetail);
            }

            await _dbContext.SaveChangesAsync(cancellationToken);
        }

        public async Task<Cart?> GetCartByUserIdAsync(string userId)
        {
            return await _dbContext.Carts
                    .Include(e => e.CartDetails)
                        .ThenInclude(cd => cd.Product)
                    .Include(e => e.CartDetails)
                        .ThenInclude(cd => cd.Product)
                            .ThenInclude(p => p!.Category)
                    .FirstOrDefaultAsync(e => e.UserId!.Equals(userId));
        }
    }
}
