using EcommerceWeb.Application.Reviews.Common.Repository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceWeb.Application.Reviews.UpdateReview
{
    public class UpdateReviewCommandHandler : IRequestHandler<UpdateReviewCommand>
    {
        private readonly IReviewRepository _reviewRepository;

        public UpdateReviewCommandHandler(IReviewRepository reviewRepository)
        {
            _reviewRepository = reviewRepository;
        }

        public async Task Handle(UpdateReviewCommand request, CancellationToken cancellationToken)
        {
            await _reviewRepository.UpdateReviewAsync(request.ReviewId, request.Rating, request.Comment);

        }
    }
}
