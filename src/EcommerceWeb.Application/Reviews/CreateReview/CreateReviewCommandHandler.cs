using EcommerceWeb.Application.Reviews.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceWeb.Application.Reviews.CreateReview
{
    public class CreateReviewCommandHandler : IRequestHandler<CreateReviewCommand>
    {
        private readonly IReviewRepository _reviewRepository;
        

        public CreateReviewCommandHandler(IReviewRepository reviewRepository)
        {
            _reviewRepository = reviewRepository;
        }

        public async Task Handle(CreateReviewCommand request, CancellationToken cancellationToken)
        {
            await _reviewRepository.AddReviewAsync(request.UserId, request.ProductId, request.Rating, request.Comment);
            
        }
    }
}
