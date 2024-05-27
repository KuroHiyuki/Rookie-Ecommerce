using EcommerceWeb.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceWeb.Application.Reviews.Common.Response
{
    public class ReviewModelAppLayer
    {
        public string? Id { get; set; }
        public string? ProductId { get; set; }
        public int Rating { get; set; }
        public string? Commnet { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public string? UserId { get; set; }
        public string? UserName { get; set;}
    }
}
