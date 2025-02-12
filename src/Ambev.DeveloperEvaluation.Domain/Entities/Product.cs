using Ambev.DeveloperEvaluation.Domain.Common;
using Ambev.DeveloperEvaluation.Domain.Contract;

namespace Ambev.DeveloperEvaluation.Domain.Entities
{
    public class Product:BaseIdentityEntity, IProduct
    {
        public Product() {
        }

        public string Title { get; set; } = string.Empty;
        public double Price { get; set; }   
        public string Description { get; set; } = string.Empty;
        public string? Image { get; set; }


        public Category Category { get; set; } = null!;
        public int CategoryId { get; set;}
        public Rating? Rating { get; set; }
        public List<CartItem> CartItem { get; set; } = [];
    }
}
