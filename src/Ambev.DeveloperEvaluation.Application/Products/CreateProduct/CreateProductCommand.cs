using Ambev.DeveloperEvaluation.Domain.Contract;
using ErrorOr;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Products.CreateProduct
{
    public class CreateProductCommand : IProduct, IRequest<ErrorOr<CreateProductResult>>
    {
        public string Title { get; set; } = string.Empty;
        public double Price { get; set; }
        public string Description { get; set; } = string.Empty;
        public string? Image { get; set; }
        public string Category { get; set; } = string.Empty;
        public RatingCommand Rating { get; set; } = new RatingCommand();  
    }
}
