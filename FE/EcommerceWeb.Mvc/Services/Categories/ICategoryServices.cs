using EcommerceWeb.Mvc.Models.Categories;

namespace EcommerceWeb.Mvc.Services.Categories
{
	public interface ICategoryServices
	{
		Task<List<CategoryVM>> GetListAsync();
	}
}
