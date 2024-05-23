using EcommerceWeb.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceWeb.Domain.Entities
{
    public class Product : BaseEntity
    {
        public string? Name { get; set; }
        public string? AliasName { get; set; }
        public string? Description { get; set; }
        public string? ImageURL { get; set; }
        public decimal UnitPrice { get; set; }
        public int Inventory {  get; set; }
        public int CountView { get; set; }
        public DateTime UpdateAt { get; set; } = DateTime.Now;
        public virtual ICollection<CartDetail> CartDetails { get; set; } = new List<CartDetail>();
        public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();
        public virtual ICollection<WishList> WishList { get; set; } = new List<WishList>();
        public virtual Category? Category { get; set; }
        public string? CategoryId { get; set; }
        public string? UserId { get; set; }
        public virtual User? User { get; set; }
        public bool IsDeleted { get; set; } = false;
        public virtual ICollection<Image> Images { get; set; } = new List<Image>();
        public virtual ICollection<Review> Reviews { get; set; } = new List<Review>();
    }
}
