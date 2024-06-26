﻿using EcommerceWeb.Mvc.Models.Reviews;
using EcommerceWeb.Presentation.Common;
using EcommerceWeb.Presentation.Reviews;

namespace EcommerceWeb.Mvc.Services.Reviews
{
    public interface IReviewServices
    {
        Task<IEnumerable<ReviewVM>> GetReviewListAsync(string productId);
        Task<bool> CreateReviewProductAsync(string ProductId ,string UserId, ReviewRequest request);
        Task<dynamic> RemoveReviewAsync(string UserId, string reviewId);
        Task<dynamic> UpdateReviewAsync(string UserId, string reviewId, ReviewRequest request);
    }
}
