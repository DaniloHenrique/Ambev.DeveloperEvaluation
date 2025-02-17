
using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.Domain.Rules
{
    public class DiscountRule : IRule<CartItem, double>
    {
        public double Execute(CartItem subject)
        {
            double n = ((double)subject.Quantity / 10);
            var d = n == 1 ? 2 : Math.Ceiling(n);
            return d / 10;
        }

        public bool Matches(CartItem subject)
        {
            return subject.Quantity > 3;
        }
    }
}
