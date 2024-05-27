
using EcommerceWeb.Application.Reviews.Common;
using EcommerceWeb.Domain.Entities;
using EcommerceWeb.Infrastructure.Common.BaseRepository;
using EcommerceWeb.Presentation.Persistences;
using Microsoft.EntityFrameworkCore;

namespace EcommerceWeb.Infrastructure.Reviews
{
    public class ReviewRepository : BaseRepository<Review>, IReviewRepository
    {
        public ReviewRepository(EcommerceDbContext context) : base(context)
        {
        }

        public async Task AddReviewAsync(string userId, string productId, int rating, string comment)
        {
            var review = new Review
            {
                Id = Guid.NewGuid().ToString(),
                UserId = userId,
                ProductId = productId,
                Rating = rating,
                Comment = comment,
                UpdateAt = DateTime.UtcNow,
                CreatedAt = DateTime.UtcNow,
            };

            _dbContext.Reviews.Add(review);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteReviewAsync(string reviewId)
        {
            var review = await _dbContext.Reviews.FindAsync(reviewId);
            if (review == null)
            {
                throw new Exception($"Invalid Comment {reviewId}");
            }

            _dbContext.Reviews.Remove(review);
            await _dbContext.SaveChangesAsync();
        }
    }
}
