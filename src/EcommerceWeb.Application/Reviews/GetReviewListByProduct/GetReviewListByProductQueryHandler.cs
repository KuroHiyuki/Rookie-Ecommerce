using EcommerceWeb.Application.Reviews.Common.Repository;
using EcommerceWeb.Application.Reviews.Common.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceWeb.Application.Reviews.GetReviewListByProduct
{
    public class GetReviewListByProductQueryHandler : IRequestHandler<GetReviewListByProductQuery, List<ReviewModelAppLayer>>
    {
        private readonly IReviewRepository _reviewRepository;

        public GetReviewListByProductQueryHandler(IReviewRepository reviewRepository)
        {
            _reviewRepository = reviewRepository;
        }

        public async Task<List<ReviewModelAppLayer>> Handle(GetReviewListByProductQuery request, CancellationToken cancellationToken)
        {
            var review = await _reviewRepository.GetReviewsByProductIdAsync(request.productId);
            if (review is null)
            {
                return [];
            }
            var ReviewDetail = review.Select(c => new ReviewModelAppLayer
            {
                Id = c.Id,
                ProductId = c.ProductId,
                Rating = c.Rating,
                Commnet = c.Comment,
                CreatedAt = c.CreatedAt,
                UpdatedAt = c.UpdateAt,
                UserId = c.UserId,
                UserName = c.User!.FirstName + " " + c.User!.LastName,

            }).ToList();
            return ReviewDetail;
        }
    }
}
