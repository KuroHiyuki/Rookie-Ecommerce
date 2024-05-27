using EcommerceWeb.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceWeb.Domain.Entities
{
    public class Review : BaseEntity
    {
        public string? Comment { get; set; }
        public int Rating { get; set; }
        public DateTime UpdateAt { get; set; } = DateTime.Now;
        public string? ProductId { get; set; }
        public string? UserId { get; set; }
        public virtual Product? Product { get; set; }
        public virtual User? User { get; set; }
    }
}
