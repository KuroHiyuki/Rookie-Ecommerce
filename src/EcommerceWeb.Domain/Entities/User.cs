using EcommerceWeb.Domain.Common.Enum;
using Microsoft.AspNetCore.Identity;



namespace EcommerceWeb.Domain.Entities
{
    public class User : IdentityUser
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set;}
        public DateTime BirthDate { get; set; }
        public Sex Sex { get; set; }
        public string? AvatarUrl { get; set; }
        public IsActive IsActive { get; set; }
        public string? AccessToken { get; set; }
        public string? RefeshToken { get; set; }
        public Role Role { get; set; }
        public virtual Cart? Cart { get; set; }
        public virtual ICollection<Review> Reviews { get; set; } = new List<Review>();
        public virtual ICollection<Order> Orders { get; set; }  = new List<Order>();
        //public virtual ICollection<OrderDetail> OrderDetails { get; } = new List<OrderDetail>();
    }
}
