using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceWeb.Presentation.Products
{
    public record ProductResponse (
        string Id,
        string Name,
        string Description,
        string ImageURL,
        decimal UnitPrice
        )
    {
    }
}
