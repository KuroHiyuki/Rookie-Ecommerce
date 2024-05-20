using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceWeb.Domain.Entities.Base
{
    public abstract class BaseEntity
    {
        public string? Id { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
