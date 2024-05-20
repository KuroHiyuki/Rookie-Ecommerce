using EcommerceWeb.Domain.Common.Enum;
using Microsoft.Win32.SafeHandles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceWeb.Domain.Entities
{
    public class Customer
    {
        public string? Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set;}
        public string? Email { get; set; }
        public string? Password { get; set; }
        public DateTime BirthDate { get; set; }
        public Sex Sex { get; set; }
        public string? AvatarUrl { get; set; }
        public IsActive IsActive { get; set; }
        public int Role {  get; set; }
        public string? AccessToken { get; set; }
        public string? RefeshToken { get; set; }
        public virtual ICollection<Order> Orders { get; set; }  = new List<Order>();
        public virtual ICollection<OrderDetail> Details { get; } = new List<OrderDetail>();
        public virtual ICollection<Cart> Carts { get; } = new List<Cart>();
    }
}
