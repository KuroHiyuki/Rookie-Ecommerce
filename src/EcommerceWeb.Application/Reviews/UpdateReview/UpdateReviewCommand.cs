using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceWeb.Application.Reviews.UpdateReview
{
    public record UpdateReviewCommand(string ReviewId, string Comment, int Rating) : IRequest
    {
    }
}
