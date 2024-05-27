using EcommerceWeb.Application.Orders.Common.Response;
using EcommerceWeb.Application.Reviews.Common.Repository;
using EcommerceWeb.Application.Reviews.Common.Response;
using EcommerceWeb.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceWeb.Application.Reviews.GetReviewList
{
    public class GetReviewListQueryHandler : IRequestHandler<GetReivewListQuery, List<ReviewModelAppLayer>>
    {
        private readonly IReviewRepository _reviewRepository;

        public GetReviewListQueryHandler(IReviewRepository reviewRepository)
        {
            _reviewRepository = reviewRepository;
        }

        public async Task<List<ReviewModelAppLayer>> Handle(GetReivewListQuery request, CancellationToken cancellationToken)
        {
            var review = await _reviewRepository.GetReviewsListAsync();

            var ReviewDetail = review.Select(c => new ReviewModelAppLayer
            {
                Id= c.Id,
                ProductId= c.ProductId,
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
