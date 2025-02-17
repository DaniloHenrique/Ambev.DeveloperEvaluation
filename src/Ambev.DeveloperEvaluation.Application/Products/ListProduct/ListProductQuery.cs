using ErrorOr;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Products.ListProduct
{
    public class ListProductQuery : IRequest<ErrorOr<List<ListProductResult>>>
    {
        public string? Category { get; set; }
    }
}
