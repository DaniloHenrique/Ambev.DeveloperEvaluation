using Ambev.DeveloperEvaluation.Domain.Contract;

namespace Ambev.DeveloperEvaluation.Application.Carts.CreateCart
{
    public class CreateCartResult : IDateable
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
    }
}
