using EcommerceWeb.Application.Categories.Common.Repository;
using EcommerceWeb.Application.Categories.Common.Response;
using EcommerceWeb.Application.Common.Interface;
using EcommerceWeb.Application.Common.Services;
using EcommerceWeb.Application.Products.Common.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace EcommerceWeb.Application.Categories.CreateCategory
{
    public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand>
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IFileStorage _fileStorageService;

        public CreateCategoryCommandHandler(
            IUnitOfWork unitOfWork,
            IFileStorage fileStorageService,
            ICategoryRepository categoryRepository)
        {
            _unitOfWork = unitOfWork;
            _fileStorageService = fileStorageService;
            _categoryRepository = categoryRepository;
        }
        public async Task Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            var newCateogrry = new CategoryModelAppLayer
            {
                Id = Guid.NewGuid().ToString(),
                Name = request.Name,
                Description = request.Description,
            };

            await _categoryRepository.CreateCateogryAsync(newCateogrry);
            await _unitOfWork.SaveAsync(cancellationToken);
        }
    }
}
