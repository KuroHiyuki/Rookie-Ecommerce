using EcommerceWeb.Application.Categories.Common.Repository;
using EcommerceWeb.Domain.Entities;
using EcommerceWeb.Infrastructure.Common.BaseRepository;
using EcommerceWeb.Presentation.Persistences;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceWeb.Infrastructure.Categories
{
    public class CategoryRepository : BaseRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(EcommerceDbContext context) : base(context)
        {
        }
        public override async Task<Category?> GetByIdAsync(string id, CancellationToken cancellationToken = default)
        {
            return await _dbContext.Categories
                .FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }
        public async Task<Category?> GetCategoryByName(string name)
        {
            return await _dbContext.Categories.FirstOrDefaultAsync(e => e.Name! == name);
        }
    }
}
