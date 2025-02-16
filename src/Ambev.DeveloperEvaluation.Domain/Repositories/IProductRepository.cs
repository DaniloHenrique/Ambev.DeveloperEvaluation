using Ambev.DeveloperEvaluation.Domain.Entities;
using ErrorOr;

namespace Ambev.DeveloperEvaluation.Domain.Repositories
{
    public interface IProductRepository:ICrudRepository<Product,int>
    {
        Task<IEnumerable<Product>> ListByCategoryAsync(int categoryId, CancellationToken cancellationToken = default);
    }
}
