using FluentValidation;
using FluentValidation.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceWeb.Application.Reviews.CreateReview
{
    public class CreateReviewCommandValidator : AbstractValidator<CreateReviewCommand>
    {
        public CreateReviewCommandValidator()
        {
            RuleFor(x => x.UserId)
                .NotEmpty();
            RuleFor(x => x.ProductId)
                .NotEmpty();
            RuleFor(x => x.Rating)
                .NotEmpty()
                .InclusiveBetween(1, 5);
            RuleFor(x => x.Comment)
                .NotEmpty()
                .MaximumLength(500);
        }
    }
}
