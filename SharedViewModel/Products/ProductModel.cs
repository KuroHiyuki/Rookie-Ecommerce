using SharedViewModel.Categories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedViewModel.Products
{
    public class ProductModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public decimal Price { get; set; }
        public int StockQuantity { get; set; }
        public CategoriesModel Category { get; set; } = null!;
        public IEnumerable<string> ImgUrls { get; set; } = new List<string>();
    }
}
