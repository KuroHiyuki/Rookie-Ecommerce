using EcommerceWeb.Application.Categories.Common.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceWeb.Application.Categories.GetAllCategory
{
    public class GetCategoryListQuery : IRequest<IEnumerable<CategoryModelAppLayer>>
    {
    }
}
