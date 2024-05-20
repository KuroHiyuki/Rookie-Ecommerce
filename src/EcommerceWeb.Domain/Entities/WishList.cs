using EcommerceWeb.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceWeb.Domain.Entities
{
    public class WishList: BaseEntity
    {
        public DateTime DateTime { get; set; }
        public string? Description { get; set; }
        public virtual Product? Product { get; set; }
        public virtual User? Customer { get; set; }
    }
}
