using ErrorOr;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Products.GetProduct
{
    public class GetProductQuery:IRequest<ErrorOr<GetProductResult>>
    {
        public int Id { get; set; }
    }
}
