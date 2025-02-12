namespace Ambev.DeveloperEvaluation.Application.Carts
{
    public class CartItemResult
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
        public ProductResult Product { get; set; } = new ProductResult();
    }
}
