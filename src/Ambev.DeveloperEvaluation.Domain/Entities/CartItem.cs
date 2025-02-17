using Ambev.DeveloperEvaluation.Domain.Common;
using Ambev.DeveloperEvaluation.Domain.Contract;

namespace Ambev.DeveloperEvaluation.Domain.Entities
{
    public class CartItem : BaseIdentityEntity, IMeasurable
    {
        public int Quantity { get; set; }

        public Cart Cart { get; set; } = null!;
        public int CartId { get; set; } 
        public Product Product { get; set; } = null!;
        public int ProductId { get; set; } 
    }
}
