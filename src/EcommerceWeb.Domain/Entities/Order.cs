using EcommerceWeb.Domain.Common.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceWeb.Domain.Entities
{
    public class Order
    {
        public string? Id { get; set; }
        public DateTime? OrderDate { get; set; }
        public DateTime? DeliveryTime { get; set;}
        public DateTime NeedDate { get; set; }
        public string? Name { get; set; }
        public string? Address { get; set; }
        public string? TelephoneNumber { get; set; }
        public PaymentMethod PaymentMethod {  get; set; }
        public decimal? DeliveryPrice { get; set; }
        public OrderStatus? Status { get; set; }
        public string? Note { get; set; }
        public virtual ICollection<OrderDetail> Details { get; set; } = new List<OrderDetail>();
        public virtual Customer? Customer { get; set; }
        public virtual Admin? Admin { get; set; }
    }
}
