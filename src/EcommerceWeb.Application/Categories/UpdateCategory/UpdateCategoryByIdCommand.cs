using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceWeb.Application.Categories.UpdateCategory
{
    public record UpdateCategoryByIdCommand(
        string Id,
        string Name,
        string Description) : IRequest
    {
    }
}
