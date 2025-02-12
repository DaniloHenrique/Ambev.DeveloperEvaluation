using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.Domain.Contract
{
    public interface IProduct:IBeing
    {
        string Title { get; set; }
        double Price { get; set; }
        string? Image { get; set; }
    }
}
