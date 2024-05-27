using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceWeb.Application.Reviews.CreateReview
{
    public record CreateReviewCommand(string UserId, string ProductId, int Rating, string Comment) : IRequest
    {
    }
}
