using EcommerceWeb.Domain.Common.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceWeb.Application.Orders.Common.Response
{
    public class OrderModelAppLayer
    {
        public string? UserName { get; set; }
        public string? Address { get; set; }
        public string? NumberPhone { get; set; }
        public PaymentMethod method { get; set; }
        public OrderStatus status { get; set; }
        public decimal TotalAmount { get; set; }
        public string? Note { get; set; }
        public DateTime OrderDate { get; set; }
        public List<ProductOrder>? products { get; set; }

    }

    public class ProductOrder
    {
        public string? ProductId { get; set; }
        public string? ProductName { get; set; }
        public decimal UnitPrice { get; set; }
        public int Quantity { get; set; }
        public string? ImageURL { get; set; }
    }
}
