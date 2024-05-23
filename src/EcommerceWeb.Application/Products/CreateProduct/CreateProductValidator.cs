using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceWeb.Application.Products.CreateProduct
{
    public class CreateProductCommandValidator : AbstractValidator<CreateProductCommand>
    {
        public CreateProductCommandValidator()
        {
            RuleFor(x => x.product.Name).NotEmpty().MinimumLength(10).MaximumLength(100);
            RuleFor(x => x.product.Description).NotEmpty().MaximumLength(500);
            RuleFor(x => x.product.Price).NotEmpty().GreaterThan(0);
            RuleFor(x => x.product.Stock).NotEmpty().GreaterThanOrEqualTo(0);
            RuleFor(x => x.product.CategoryId).NotEmpty();
        }
    }
}
