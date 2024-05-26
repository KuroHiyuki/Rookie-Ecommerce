using EcommerceWeb.Application.Categories.Common.Repository;
using EcommerceWeb.Application.Categories.Common.Response;
using EcommerceWeb.Application.Common.Services.Paginations;
using EcommerceWeb.Application.Products.Common.Interfaces;
using EcommerceWeb.Application.Products.Common.Response;
using EcommerceWeb.Application.Products.GetListProducts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace EcommerceWeb.Application.Categories.GetById
{
    public class GetCategoryByIdQueryHandler : IRequestHandler<GetCategoryByIdQuery, CategoryModelAppLayer>
    {
        private readonly ICategoryRepository _categoryRepository;
        public GetCategoryByIdQueryHandler( ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }
        public async Task<CategoryModelAppLayer> Handle(GetCategoryByIdQuery request, CancellationToken cancellationToken)
        {
            var category = await _categoryRepository.GetByIdAsync(request.id, cancellationToken);
            if (category is null)
            {
                throw new ArgumentException();
            }
            var Reults = new CategoryModelAppLayer
            {
                Id = category.Id,
                Name = category.Name,
                Description = category.Description,
            };
            return Reults!;
        }
    }
}
