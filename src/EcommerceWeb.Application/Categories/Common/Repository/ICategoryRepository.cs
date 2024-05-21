using EcommerceWeb.Application.Common.Interface;
using EcommerceWeb.Domain.Entities;

namespace EcommerceWeb.Application.Categories.Common.Repository
{
    public interface ICategoryRepository : IBaseRepository<Category>
    {
        Task<Category?> GetCategoryByName(string name);
    }
}
