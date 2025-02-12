using Ambev.DeveloperEvaluation.Domain.Contract;

namespace Ambev.DeveloperEvaluation.Application.Products.GetProduct
{
    public class GetProductResult : IProduct
    {
        public string Title { get; set; } = string.Empty;
        public double Price { get; set; }
        public string Description { get; set; } = string.Empty;
        public string? Image { get; set; }
        public string Category { get; set; } = string.Empty;
        public RatingResult Rating { get;set; } = new RatingResult();
    }
}
