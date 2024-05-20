using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceWeb.Domain.Entities
{
    public class Category
    {
        public string? Id { get; set; }
        public string? Name { get; set; }    
        public string? AliasName { get; set; }
        public string? Description { get; set; }
        public string? Image {  get; set; }
        public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

    }
}
