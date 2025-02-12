using Ambev.DeveloperEvaluation.Domain.Common;
using Ambev.DeveloperEvaluation.Domain.Contract;

namespace Ambev.DeveloperEvaluation.Domain.Entities
{
    public class Cart : BaseEntity<int>, IDateble
    {
        public DateTime Date { get; set; }
        public List<CartItem> Items { get; set; } = new List<CartItem>();

        public Sale? Sale { get; set; }
    }
}
