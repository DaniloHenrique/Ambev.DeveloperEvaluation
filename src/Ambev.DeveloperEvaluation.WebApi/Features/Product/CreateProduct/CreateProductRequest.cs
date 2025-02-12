using Ambev.DeveloperEvaluation.Domain.Contract;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Product.CreateProduct
{
    public class CreateProductRequest : IProduct
    {
        public string Title { get; set; } = string.Empty;
        public double Price { get; set; }
        public string Description { get; set; } = string.Empty;
        public string? Image { get; set; }
        public string Category { get; set; } = string.Empty;
        public RatingRequest Rating { get; set; } = new RatingRequest();

    }
}
