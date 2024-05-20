using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceWeb.Domain.Entities
{
    public class QandA
    {
        public string? Id { get; set; }
        public string? Question { get; set; }
        public string? Answer { get; set; }
        public DateTime? AnswerDate { get; set;}
        public virtual Admin? Admin { get; set; }
    }
}
