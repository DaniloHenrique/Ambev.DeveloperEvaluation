using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using ErrorOr;

namespace Ambev.DeveloperEvaluation.Domain.Services
{
    public interface IProductService
    {
        IProductRepository ProductRepository { get; }
        ICategoryRepository CategoryRepository { get; }

        Task<ErrorOr<Product>> CreateAsync(Product product);
        Task<ErrorOr<Updated>> UpdateAsync(Product product);
        Task<ErrorOr<Deleted>> RemoveAsync(Product product);
        Task<ErrorOr<Product>> GetAsync(int id);
        Task<ErrorOr<IList<Product>>> ListAsync();
    }
}
