using Ambev.DeveloperEvaluation.Domain.Contract;
using ErrorOr;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Carts.CreateCart
{
    public class CreateCartCommand:IRequest<ErrorOr<CreateCartResult>>
    {
        public List<CartItemCommand> Items { get; set; } = [];
        public UserCommand User { get; set; } = new UserCommand();
    }
}
