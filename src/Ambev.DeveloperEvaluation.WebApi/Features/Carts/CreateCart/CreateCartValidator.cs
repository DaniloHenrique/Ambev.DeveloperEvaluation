using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Carts.CreateCart
{
    public class CreateCartValidator:AbstractValidator<CreateCartRequest>
    {
        public CreateCartValidator() 
        {
            RuleForEach(cart => cart.Items).SetValidator(v=>new CartItemValidator());
            RuleFor(cart=>cart.User).SetValidator(v=>new CreateCartUserValidator());
        }
    }
}
