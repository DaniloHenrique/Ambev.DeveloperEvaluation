using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Carts.GetCart
{
    public class GetCartValidator:AbstractValidator<GetCartRequest>
    {
        public GetCartValidator()
        {
            RuleFor(cart => cart.Id).GreaterThan(0).WithMessage("Id must be a positive integer");
        }
    }
}
