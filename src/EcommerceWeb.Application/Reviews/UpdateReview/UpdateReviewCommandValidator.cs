using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceWeb.Application.Reviews.UpdateReview
{
    public class UpdateReviewCommandValidator : AbstractValidator<UpdateReviewCommand>
    {
        public UpdateReviewCommandValidator()
        {
            RuleFor(x => x.ReviewId)
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
