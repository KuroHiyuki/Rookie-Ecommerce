using EcommerceWeb.Mvc.Models.Reviews;
using EcommerceWeb.Presentation.Common;
using EcommerceWeb.Presentation.Reviews;

namespace EcommerceWeb.Mvc.Services.Reviews
{
    public interface IReviewServices
    {
        Task<IEnumerable<ReviewVM>> GetReviewListAsync(string productId);
        Task<bool> CreateReviewProductAsync(string ProductId, ReviewRequest request);
        Task RemoveReviewAsync(string productId, string reviewId);
    }
}
