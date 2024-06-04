using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceWeb.Application.Reviews.DeleteReview
{
    public record DeleteReviewCommand (string UserId, string ReviewId) : IRequest
    {
    }
}
