using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceWeb.Domain.Entities
{
    public class WishList
    {
        public string? Id { get; set; }
        public DateTime DateTime { get; set; }
        public string? Description { get; set; }
        public virtual Product? Product { get; set; }
        public virtual Customer? Customer { get; set; }
    }
}
