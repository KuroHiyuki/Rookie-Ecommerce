using EcommerceWeb.Application.Common.Interface;
using EcommerceWeb.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceWeb.Application.Reviews.Common
{
    public interface IReviewRepository : IBaseRepository<Review>
    {
        Task AddReviewAsync(string userId, string productId, int rating, string comment);
    }
}
