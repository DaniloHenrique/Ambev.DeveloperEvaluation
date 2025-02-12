using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Carts.UpdateCart
{
    public class UpdateCartValidator:AbstractValidator<UpdateCartRequest>
    {
        public UpdateCartValidator()
        {
            RuleForEach(cart => cart.Items).SetValidator(v => new UpdateCartItemValidator());

            RuleFor(cart => cart.Id).GreaterThan(0).WithMessage("Id must be a positive integer");
        }
    }
}
