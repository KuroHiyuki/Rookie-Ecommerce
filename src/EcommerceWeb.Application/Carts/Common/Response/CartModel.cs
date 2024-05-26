using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceWeb.Application.Carts.Common.Response
{
    public class CartModel
    {
        public string? UserId { get; set; }
        public string? ProductId { get; set; }
        public int Quantity { get; set; }
    }
}
