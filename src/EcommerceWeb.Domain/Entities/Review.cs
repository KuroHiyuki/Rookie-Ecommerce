using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceWeb.Domain.Entities
{
    public class Review
    {
        public string? Id { get; set; }
        public string? Comment { get; set; }
        public decimal Rating { get; set; }
        public virtual ICollection<Product> Products { get; set; } = new List<Product>();   
        public virtual Customer? Customer { get; set; }
    }
}
