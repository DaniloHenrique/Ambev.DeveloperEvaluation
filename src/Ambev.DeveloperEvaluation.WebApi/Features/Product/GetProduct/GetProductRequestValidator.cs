using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Product.GetProduct
{
    public class GetProductRequestValidator:AbstractValidator<GetProductRequest>
    {
        public GetProductRequestValidator()
        {
            RuleFor(product => product.Id)
                .GreaterThan(0)
                .WithMessage("Id must be a positive integer");
        }
    }
}
