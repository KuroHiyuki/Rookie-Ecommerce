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
        public string? Description { get; set; }
        public string? ImageURL {  get; set; }
        public string? CategoryId { get; set; }
        public virtual ICollection<Category> Categories { get; set; } = new List<Category>();
        public virtual ICollection<Product> Products { get; set; } = new List<Product>();

    }
}
