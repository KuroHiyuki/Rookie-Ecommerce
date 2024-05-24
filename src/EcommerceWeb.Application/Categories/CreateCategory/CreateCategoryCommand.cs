using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceWeb.Application.Categories.CreateCategory
{
    public record CreateCategoryCommand ( string Name, string Description): IRequest
    {
    }
}
