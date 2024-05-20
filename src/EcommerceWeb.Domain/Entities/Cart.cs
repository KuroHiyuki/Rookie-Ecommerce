using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceWeb.Domain.Entities
{
    public class Cart
    {
        public string? Id { get; set; }
        public virtual Customer? Customer { get; set; }
    }
}
