using Ambev.DeveloperEvaluation.Domain.Common;
using Ambev.DeveloperEvaluation.Domain.Contract;

namespace Ambev.DeveloperEvaluation.Domain.Entities
{
    public class Rating:BaseIdentityEntity, IRating
    {
        public Rating() 
        {
            Product = new Product();
        }
        public double Rate { get; set; }
        public int Count { get; set; }

        public Product Product { get; set; }
        public int ProductId { get => Product.Id;set=>Product.Id = value; } 
    }
}
