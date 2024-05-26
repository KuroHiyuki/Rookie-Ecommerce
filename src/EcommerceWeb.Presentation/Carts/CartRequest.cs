using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceWeb.Presentation.Carts
{
    public class CartRequest
    {
        public int Quantity { get; set; }
        public string? ProductId { get; set; }
    }
}
