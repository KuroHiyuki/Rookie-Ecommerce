using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceWeb.Application.Common.Services.Paginations
{
    public class PageQuery
    {
        public string? SearchTerm { get; set; }
        public string? SortOrder { get; set; }
        public string? SortColumn { get; set; }
        public int Page { get; set; } = 1;
        public int PageSize { get; set; } = 10;
    }
}
