using EcommerceWeb.Domain.Entities.Base;

namespace EcommerceWeb.Domain.Entities
{
    public class CartDetail:BaseEntity
    {
        public int Quantity { get; set; }
        public string? ProductId { get; set; }
        public virtual Product? Product { get; set; }
        public virtual Cart? Cart { get; set;}
        public string? CartId { get; set; }
    }
}