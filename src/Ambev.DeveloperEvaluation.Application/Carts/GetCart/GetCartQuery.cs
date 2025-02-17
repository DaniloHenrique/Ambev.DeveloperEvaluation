using ErrorOr;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Carts.GetCart
{
    public class GetCartQuery:IRequest<ErrorOr<GetCartResult>>
    {
        public int Id { get; set; }
    }
}
