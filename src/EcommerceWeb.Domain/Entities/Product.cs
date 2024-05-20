using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceWeb.Domain.Entities
{
    public class Product
    {
        public string? Id { get; set; }
        public string? Name { get; set; }
        public string? AliasName { get; set; }
        public string? Description { get; set; }
        public string? ImageURL { get; set; }
        public decimal UnitPrice { get; set; }
        public DateTime CreateDate { get; set; }
        public int CountView { get; set; }
        public virtual ICollection<OrderDetail> Details { get; set; } = new List<OrderDetail>();
        public virtual ICollection<WishList> WishList { get; set; } = new List<WishList>();
        public virtual Category? Category { get; set; }
        public virtual Vendor? Vendor { get; set; }

    }
}
