using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.Domain.Specifications
{
    public class InvalidCartItemSpecification : ISpecification<CartItem>
    {
        public bool IsSatisfiedBy(CartItem entity)
        {
            return entity.Quantity > 20;
        }
    }
}
