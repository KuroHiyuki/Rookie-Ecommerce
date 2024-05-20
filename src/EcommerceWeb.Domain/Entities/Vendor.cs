using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceWeb.Domain.Entities
{
    public class Vendor
    {
        public string? Id { get; set; }
        public string? Name { get; set; }
        public string? Logo { get; set; }
        public string? ContractAddress { get; set; }
        public string? Email { get; set; }
        public string? Address { get; set; }
        public string? Description { get; set; }
        public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
    }
}
