using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Carts.UpdateCart
{
    public class UpdateCartItemValidator:AbstractValidator<UpdateCartItemRequest>
    {
        public UpdateCartItemValidator()
        {
            RuleFor(cart=>cart.Id).GreaterThan(0).WithMessage("Cart Item Id must be a positive integer");

            RuleFor(cart => cart.ProductId).GreaterThan(0).WithMessage("Product Id must be a positive integer");

            RuleFor(cart => cart.Quantity).LessThanOrEqualTo(20).WithMessage("It's allowed at maximum 20 identical items");
            RuleFor(cart => cart.Quantity).GreaterThan(0).WithMessage("Quantity must be a positive integer");
        }
    }
}
