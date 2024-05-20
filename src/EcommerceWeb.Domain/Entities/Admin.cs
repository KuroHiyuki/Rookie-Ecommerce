using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceWeb.Domain.Entities
{
    public  class Admin
    {
        public string? Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }

        public virtual ICollection<Topic> TopicsList { get; set; } = new List<Topic>();

        public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

        public virtual ICollection<QandA> QandAs { get; set; } = new List<QandA>();

        public virtual ICollection<Permission> Permissions { get; set; } = new List<Permission>();
        public virtual ICollection<Review> Reviews { get; set; } = new List<Review>();  
    }
}
