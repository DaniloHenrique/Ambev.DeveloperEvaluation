using Ambev.DeveloperEvaluation.Domain.CompiledQueries;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Exceptions;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using ErrorOr;
using Microsoft.EntityFrameworkCore;

namespace Ambev.DeveloperEvaluation.ORM.Repositories
{
    /// <summary>
    /// Database repository that handles operations over <see cref="Product"/> entity
    /// </summary>
    public class ProductRepository : CrudRepository<DefaultContext,Product,int>, IProductRepository
    {
        readonly Func<DefaultContext, int, CancellationToken, Task<List<Product>>> _listByCategoryAsyncQuery;

        /// <summary>
        /// Create instance of <see cref="ProductRepository"/>
        /// </summary>
        /// <param name="context"></param>
        public ProductRepository(DefaultContext context):base(context)
        {
            _listByCategoryAsyncQuery = ProductCompiledQueries<DefaultContext>.ListByCategoryQueryAsync;
        }

        public async Task<IList<Product>> ListByCategoryAsync(int categoryId, CancellationToken cancellationToken = default)
        {
            try
            {
                var products = await _listByCategoryAsyncQuery(Context, categoryId, cancellationToken);
                
                return products.ToList();
            }
            catch(Exception exception)
            {
                throw new DatabaseOperationException(exception.Message);
            }
        }
    }
}
