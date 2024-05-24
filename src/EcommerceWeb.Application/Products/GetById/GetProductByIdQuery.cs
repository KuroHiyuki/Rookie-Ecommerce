using EcommerceWeb.Application.Products.Common.Response;
using ErrorOr;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceWeb.Application.Products.GetById
{
    public record GetProductByIdQuery(string Id) : IRequest<ProductModelAppLayer>
    {
    }
}
