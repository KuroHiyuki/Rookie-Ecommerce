using EcommerceWeb.Application.Reviews.Common.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceWeb.Application.Reviews.GetReviewListByProduct
{
    public record GetReviewListByProductQuery(string productId) : IRequest<List<ReviewModelAppLayer>>
    {
    }
}
