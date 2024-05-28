using EcommerceWeb.Application.Common.Services.Paginations;
using EcommerceWeb.Application.Products.Common.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceWeb.Application.Products.GetbyCategory
{
    public record GetProductByCategoryQuery(
        string CategoryName,
        PageQuery Query
        ) : IRequest<Paginated<ProductModelAppLayer>>
    {
    }
}
