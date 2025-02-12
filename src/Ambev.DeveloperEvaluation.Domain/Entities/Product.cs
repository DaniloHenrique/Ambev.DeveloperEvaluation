using Ambev.DeveloperEvaluation.Domain.Common;
using Ambev.DeveloperEvaluation.Domain.Contract;

namespace Ambev.DeveloperEvaluation.Domain.Entities
{
    public class Product:BaseIdentityEntity, IProduct
    {
        public Product() {
            Category = new Category();
        }

        public string Title { get; set; } = string.Empty;
        public double Price { get; set; }   
        public string Description { get; set; } = string.Empty;
        public string? Image { get; set; } = string.Empty;
        

        public Category Category { get; set; }
        public int CategoryId { get => Category.Id; set => Category.Id = value; }
        public Rating? Rating { get; set; }
        public List<CartItem> CartItem { get; set; } = new List<CartItem>();
    }
}
