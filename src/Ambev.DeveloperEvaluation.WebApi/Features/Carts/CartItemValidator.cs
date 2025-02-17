using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Carts
{
    public class CartItemValidator:AbstractValidator<CartItemRequest>
    {
        public CartItemValidator()
        {
            RuleFor(cart => cart.ProductId)
                .GreaterThan(0)
                .WithMessage("Product Id must be a positive integer");

            RuleFor(cart => cart.Quantity)
                .GreaterThan(0)
                .WithMessage("Quantity must be a positive integer");
        }
    }
}
