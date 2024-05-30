using EcommerceWeb.Mvc.Models.Reviews;
using EcommerceWeb.Presentation.Common;

namespace EcommerceWeb.Mvc.Services.Reviews
{
    public interface IReviewServices
    {
        Task<IEnumerable<ReviewVM>> GetReviewListAsync(string productId);
        Task CreateReviewProduct(string ProductId, string Comment, int Rating);
        Task RemoveReviewAsync(string productId, string reviewId);
    }
}
