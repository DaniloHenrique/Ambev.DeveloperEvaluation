using Ambev.DeveloperEvaluation.Domain.Contract;

namespace Ambev.DeveloperEvaluation.Application.Products
{
    public class RatingResult : IRating
    {
        public double Rate { get; set; }
        public int Count { get; set; }
    }
}
