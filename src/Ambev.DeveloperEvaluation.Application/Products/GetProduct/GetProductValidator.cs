using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Products.GetProduct
{
    public class GetProductValidator:AbstractValidator<GetProductCommand>
    {
        public GetProductValidator()
        {
            RuleFor(product => product.Id)
                .GreaterThan(0)
                .WithMessage("Id must be a positive integer");
        }
    }
}
