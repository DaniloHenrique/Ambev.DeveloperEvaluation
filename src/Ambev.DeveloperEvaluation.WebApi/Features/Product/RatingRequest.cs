using Ambev.DeveloperEvaluation.Domain.Contract;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Product
{
    public class RatingRequest : IRating
    {
        public double Rate { get; set; }
        public int Count { get; set; }
    }
}
