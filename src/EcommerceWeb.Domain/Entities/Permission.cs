using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceWeb.Domain.Entities
{
    public class Permission
    {
        public string? Id { get; set; }
        public string? Name { get; set; }
        public bool Add {  get; set; }
        public bool Update { get; set; }
        public bool Delete { get; set; }
        public bool View {  get; set; }
        public virtual Department? Department { get; set; }  
    }
}
