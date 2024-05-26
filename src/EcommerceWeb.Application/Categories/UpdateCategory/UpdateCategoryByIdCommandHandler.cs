using EcommerceWeb.Application.Categories.Common.Repository;
using EcommerceWeb.Application.Common.Interface;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceWeb.Application.Categories.UpdateCategory
{
    public class UpdateCategoryByIdCommandHandler : IRequestHandler<UpdateCategoryByIdCommand>
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IUnitOfWork _unitOfWork;
        public UpdateCategoryByIdCommandHandler(ICategoryRepository categoryRepository, IUnitOfWork unitOfWork)
        {
            _categoryRepository = categoryRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(UpdateCategoryByIdCommand command, CancellationToken cancellationToken)
        {
            var category = await _categoryRepository.GetByIdAsync(command.Id);
            if(category is null)
            {
                throw new Exception($"Not found category ID : {command.Id}");
            }
            {
                category.Name = command.Name;
                category.Description = command.Description;
            }
            _categoryRepository.Update(category);
            await _unitOfWork.SaveAsync(cancellationToken);
        }
    }
}
