using ErrorOr;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Carts.UpdateCart
{
    public class UpdateCartCommand:IRequest<ErrorOr<Updated>>
    {
        public int Id { get; set; }
        public List<UpdateCartItemCommand> Items { get; set; } = [];
        public Guid UserId { get; set; }
    }
}
