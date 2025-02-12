using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Carts.CreateCart
{
    public class CreateCartItemValidator:AbstractValidator<CartItemRequest>
    {
        public CreateCartItemValidator()
        {
            RuleFor(cart => cart.ProductId).GreaterThan(0).WithMessage("Product Id must be a positive integer");

            RuleFor(cart => cart.Quantity).LessThan(20).WithMessage("It's allowed only 20 identical items");
        }
    }
}
