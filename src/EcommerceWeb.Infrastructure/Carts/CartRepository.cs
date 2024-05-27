using EcommerceWeb.Application.Carts.Common.Repositories;
using EcommerceWeb.Application.Carts.Common.Response;
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
             .FirstOrDefaultAsync(c => c.UserId == userId && c.CartDetails.Any(),cancellationToken);

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

        public Task DeleteProductFromCart(string UserId, int productId)
        {
            throw new NotImplementedException();
        }

        public async Task<Cart> GetCartByUserId(string userId)
        {
            var cart = await _dbContext.Carts
                .Include(c => c.CartDetails)
                .ThenInclude(cd => cd.Product)
                .FirstOrDefaultAsync(c => c.UserId == userId && c.CartDetails.Any());
            if(cart is null)
            {
                throw new Exception($"User id {userId} haven't added a product to the cart yet");
            }
            return cart;
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

        public async Task<List<CartModelAppLayer>> GetProductsInCart(string CartId)
        {
            var cart = await _dbContext.Carts
                .Include(c => c.CartDetails)
                .ThenInclude(cd => cd.Product)
                .Where(a => a.Id == CartId).FirstOrDefaultAsync();
            if(cart is null)
            {
                return new List<CartModelAppLayer> { };
            }

            var product =  cart.CartDetails.Select(c => new CartModelAppLayer
            {
                ProductId = c.ProductId,
                Name = c.Product!.Name!,
                Quantity = c.Quantity,
                Images = c.Product.ImageURL,
                Price = c.Product.UnitPrice,
                Description = c.Product.Description!
            });
            List<CartModelAppLayer> List = product.ToList();
            return List;
        }

        public async Task UpdateProductQuantity(string cartId, string productId, int quantity)
        {
            var cartDetail = await _dbContext.CartDetails
            .FirstOrDefaultAsync(cd => cd.CartId == cartId && cd.ProductId == productId);

            if (cartDetail != null)
            {
                cartDetail.Quantity = quantity;
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}
