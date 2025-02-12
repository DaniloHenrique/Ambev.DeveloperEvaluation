using Ambev.DeveloperEvaluation.Domain.Contract;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Product.GetProduct
{
    public class GetProductResponse : IProduct
    {
        public string Title { get; set; } = string.Empty;
        public double Price { get; set; }
        public string Description { get; set; } = string.Empty;
        public string? Image { get; set; }
        public string Category { get; set; } = string.Empty;
        public RatingResponse Rating { get;set; } = new RatingResponse();
    }
}
