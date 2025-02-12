using Ambev.DeveloperEvaluation.Application.Carts;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Carts.GetCart
{
    public class GetCartResponse
    {
        public DateTime Date { get; set; }
        public List<CartItemResponse> Items { get; set; } = [];
        public UserResponse User { get; set; } = null!;
    }
}
