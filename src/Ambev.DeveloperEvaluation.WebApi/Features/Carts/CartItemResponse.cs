
namespace Ambev.DeveloperEvaluation.WebApi.Features.Carts
{
    public class CartItemResponse
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
        public ProductResponse Product { get; set; } = new ProductResponse();
    }
}
