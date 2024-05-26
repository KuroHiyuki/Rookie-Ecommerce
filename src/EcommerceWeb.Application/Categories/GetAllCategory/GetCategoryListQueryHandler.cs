using EcommerceWeb.Application.Categories.Common.Repository;
using EcommerceWeb.Application.Categories.Common.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EcommerceWeb.Application.Categories.GetAllCategory
{
    public class GetCategoryListQueryHandler : IRequestHandler<GetCategoryListQuery, IEnumerable<CategoryModelAppLayer>>
    {
        private readonly ICategoryRepository _categoryRepository;

        public GetCategoryListQueryHandler(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<IEnumerable<CategoryModelAppLayer>> Handle(GetCategoryListQuery request, CancellationToken cancellationToken)
        {
            var categoryList = await _categoryRepository.GetListAsync(cancellationToken: cancellationToken);
            var result = categoryList.Select(c => new CategoryModelAppLayer
            {
                Id = c.Id,
                Name = c.Name,
                Description = c.Description,
            }).ToList();
            return result;
        }
    }
}
