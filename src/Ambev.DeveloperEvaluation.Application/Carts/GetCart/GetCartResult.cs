namespace Ambev.DeveloperEvaluation.Application.Carts.GetCart
{
    public class GetCartResult
    {
        public DateTime Date { get; set; }
        public List<CartItemResult> Items{ get; set; } = [];
    }
}
