using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceWeb.Domain.Entities
{
    public class OrderDetail
    {
        public string? Id { get; set; }
        public decimal UnitPrice { get; set; }
        public int Volume { get; set; }
        public decimal DiscountPrice { get; set; }
        public virtual Order? Order { get; set; }    
        public virtual Product? Product { get; set; }
    }
}
