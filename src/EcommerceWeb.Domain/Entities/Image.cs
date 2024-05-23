using EcommerceWeb.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceWeb.Domain.Entities
{
    public class Image : BaseEntity
    {
        public string Url { get; set; } = null!;
        public Product Product { get; set; } = null!;
    }
}
