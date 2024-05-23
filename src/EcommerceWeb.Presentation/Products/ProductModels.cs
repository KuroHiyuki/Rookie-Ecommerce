using EcommerceWeb.Presentation.Categories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceWeb.Presentation.Products
{
    public class ProductModels
    {
        public string? Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public int StockQuantity { get; set; }
        public CategoryModel? Category { get; set; }
        public string? ImgUrls { get; set; } 
    }
}
