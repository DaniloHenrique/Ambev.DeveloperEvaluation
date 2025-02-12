using Ambev.DeveloperEvaluation.Domain.Common;
using Ambev.DeveloperEvaluation.Domain.Contract;

namespace Ambev.DeveloperEvaluation.Domain.Entities
{
    public class Cart : BaseEntity<int>, IDateble
    {
        public Cart() 
        {
            User = new User();
        }
        public DateTime Date { get; set; }
        public List<CartItem> Items { get; set; } = new List<CartItem>();
        //public Sale? Sale { get; set; }
        public User User { get; set; } 
        public Guid UserId { get => User.Id; set => User.Id = value; }
    }
}
