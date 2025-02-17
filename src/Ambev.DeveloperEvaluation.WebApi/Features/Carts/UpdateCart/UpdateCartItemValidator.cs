using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Carts.UpdateCart
{
    public class UpdateCartItemValidator:AbstractValidator<UpdateCartItemRequest>
    {
        public UpdateCartItemValidator()
        {
            RuleFor(cart => cart.ProductId)
                .GreaterThanOrEqualTo(1)
                .WithMessage("Product Id must be a positive integer");

            RuleFor(cart => cart.Quantity)
                .GreaterThanOrEqualTo(1)
                .WithMessage("Quantity must be a positive integer");
        }
    }
}
