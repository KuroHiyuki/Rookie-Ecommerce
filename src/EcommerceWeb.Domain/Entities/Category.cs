using EcommerceWeb.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceWeb.Domain.Entities
{
    public class Category: BaseEntity
    {
        public string? Name { get; set; }    
        public string? AliasName { get; set; }
        public string? Description { get; set; }
        public string? ImageURL {  get; set; }
        public virtual ICollection<Product> Orders { get; set; } = new List<Product>();

    }
}
