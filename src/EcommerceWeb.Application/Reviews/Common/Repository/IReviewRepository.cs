using EcommerceWeb.Application.Common.Interface;
using EcommerceWeb.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceWeb.Application.Reviews.Common.Repository
{
    public interface IReviewRepository : IBaseRepository<Review>
    {
        Task AddReviewAsync(string userId, string productId, int rating, string comment);
        Task DeleteReviewAsync(string reviewId);
        Task<List<Review>> GetReviewsListAsync();
        Task<List<Review>> GetReviewsByProductIdAsync(string productId);
        Task UpdateReviewAsync(string reviewId, int rating, string comment);
    }
}
