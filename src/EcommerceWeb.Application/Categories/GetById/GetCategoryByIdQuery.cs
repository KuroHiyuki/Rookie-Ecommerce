using EcommerceWeb.Application.Categories.Common.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceWeb.Application.Categories.GetById
{
    public record GetCategoryByIdQuery(string id): IRequest<CategoryModelAppLayer>
    {
    }
}
