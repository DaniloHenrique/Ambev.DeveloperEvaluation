namespace Ambev.DeveloperEvaluation.WebApi.Features.Carts.CreateCart
{
    public class CreateCartRequest
    {
        public List<CartItemRequest> Items { get; set; } = [];
        public UserRequest User { get; set; } = new UserRequest();
    }
}
