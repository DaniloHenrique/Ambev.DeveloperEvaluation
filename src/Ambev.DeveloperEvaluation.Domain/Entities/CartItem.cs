using Ambev.DeveloperEvaluation.Domain.Common;
using Ambev.DeveloperEvaluation.Domain.Contract;
using Ambev.DeveloperEvaluation.Domain.Rules;

namespace Ambev.DeveloperEvaluation.Domain.Entities
{
    public class CartItem : BaseEntity<int>, IMeasurable
    {
        public CartItem()
        {
            Product = new Product();
            Cart = new Cart();
        }
        public int Quantity { get; set; }

        public Cart Cart { get; set; }
        public int CartId { get=>Cart.Id; set=>Cart.Id = value; } 
        public Product Product { get; set; }
        public int ProductId { get => Product.Id;set=> ProductId = value; } 
        public double Discount { get => Quantity > 3 ? Rules.Discount.Rule(Quantity) : 0; }
    }
}
