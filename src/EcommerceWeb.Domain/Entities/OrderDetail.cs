using EcommerceWeb.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceWeb.Domain.Entities
{
    public class OrderDetail : BaseEntity
    {
        public decimal UnitPrice { get; set; }
        public int Quantity { get; set; }
        public decimal DiscountPrice { get; set; }
        public string? ProductId { get; set; }
        public string? OrderId { get; set; }
        public virtual Order? Order { get; set; }    
        public virtual Product? Product { get; set; }
    }
}
