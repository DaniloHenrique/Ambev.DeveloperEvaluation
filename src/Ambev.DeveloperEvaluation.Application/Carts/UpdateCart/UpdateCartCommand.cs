using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Carts.UpdateCart
{
    public class UpdateCartCommand:IRequest<UpdateCartResult>
    {
        public int Id { get; set; }
        public List<UpdateCartItemCommand> Items { get; set; } = [];
    }
}
