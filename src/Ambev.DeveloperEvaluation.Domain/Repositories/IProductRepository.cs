using Ambev.DeveloperEvaluation.Domain.Common;
using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.Domain.Repositories
{
    public interface IProductRepository:ICrudRepository<Product,int>
    {
        Task<IEnumerable<Product>> ListByCategoryAsync(int categoryId, CancellationToken cancellationToken = default);
        Task<Product?> Get(int id);
    }
}
