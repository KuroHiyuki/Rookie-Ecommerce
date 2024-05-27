using EcommerceWeb.Application.Reviews.Common.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceWeb.Application.Reviews.GetReviewList
{
    public record GetReivewListQuery : IRequest<List<ReviewModelAppLayer>>
    {
    }
}
