using ErrorOr;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceWeb.Application.Products.UpdateProduct
{
    public record UpdateProductCommand (
        string Id,
        string Name,
        string Description,
        decimal UnitPrice,
        int Inventorry,
        string CategoryId,
        IFormFileCollection? Images 
        ) : IRequest;
    
}
