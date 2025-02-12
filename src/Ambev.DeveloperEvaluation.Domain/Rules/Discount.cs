
namespace Ambev.DeveloperEvaluation.Domain.Rules
{
    public static class Discount
    {
        public static double Rule(int quantity)
        {
            double n = ((double)quantity / 10);
            var d = n == 1 ? 2 : Math.Ceiling(n);
            return d / 10;
        }
    }
}
