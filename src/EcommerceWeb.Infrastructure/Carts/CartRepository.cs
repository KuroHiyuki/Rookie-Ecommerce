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


        public async Task<Cart?> GetCartByUserIdAsync(string userId)
        {
            return await _dbContext.Carts
                    .Include(e => e.CartDetails)
                        .ThenInclude(cd => cd.Product)
                    .Include(e => e.CartDetails)
                        .ThenInclude(cd => cd.Product)
                            .ThenInclude(p => p.Category)
                    .FirstOrDefaultAsync(e => e.UserId.Equals(userId));
        }
    }
}
