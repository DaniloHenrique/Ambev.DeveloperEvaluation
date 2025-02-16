using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using ErrorOr;

namespace Ambev.DeveloperEvaluation.Domain.Services
{
    public interface IProductService
    {
        IProductRepository ProductRepository { get; }
        ICategoryRepository CategoryRepository { get; }

        Task<ErrorOr<Product>> CreateAsync(Product product, CancellationToken cancellationToken);
        Task<ErrorOr<Updated>> UpdateAsync(Product product, CancellationToken cancellationToken);
        Task<ErrorOr<Deleted>> RemoveAsync(Product product, CancellationToken cancellationToken);
        Task<ErrorOr<Product>> GetAsync(int id, CancellationToken cancellationToken);
        Task<ErrorOr<IList<Product>>> ListAsync(CancellationToken cancellationToken);
        Task<ErrorOr<IList<Product>>> ListByCategoryAsync(int categoryId, CancellationToken cancellationToken);
    }
}
