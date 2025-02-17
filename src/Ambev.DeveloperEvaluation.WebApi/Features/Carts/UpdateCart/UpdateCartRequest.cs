namespace Ambev.DeveloperEvaluation.WebApi.Features.Carts.UpdateCart
{
    public class UpdateCartRequest
    {
        public int Id { get; set; }
        public List<UpdateCartItemRequest> Items { get; set; } = [];
        public Guid UserId { get; set; }
    }
}
