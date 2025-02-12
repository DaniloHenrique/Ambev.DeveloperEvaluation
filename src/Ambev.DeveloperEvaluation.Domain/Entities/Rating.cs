using Ambev.DeveloperEvaluation.Domain.Common;
using Ambev.DeveloperEvaluation.Domain.Contract;

namespace Ambev.DeveloperEvaluation.Domain.Entities
{
    public class Rating:BaseIdentityEntity, IRating
    {
        public double Rate { get; set; }
        public int Count { get; set; }

        public Product Product { get; set; } = null!;
        public int ProductId { get; set; } 
    }
}
