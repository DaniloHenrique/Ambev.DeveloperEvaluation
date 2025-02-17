using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Product.ListProduct
{
    public class ListProductRequestValidator:AbstractValidator<ListProductRequest>
    {
        public ListProductRequestValidator()
        {
            When(p => p.Category is not null, () =>
            {
                RuleFor(p => p.Category)
                    .NotEmpty()
                    .WithMessage("Category '' invalid");

                RuleFor(p => p.Category)
                    .Length(3, 50)
                    .WithMessage("Category must have between 3 and 50 characters");
            });
        }
    }
}
