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
        /// <param name="context">Default Context of database</param>
        public ProductRepository(DefaultContext context):base(context)
        {
            _listByCategoryAsyncQuery = ProductCompiledQueries<DefaultContext>.ListByCategoryQueryAsync;
        }

        /// <summary>
        /// Retrieves a list of <see cref="Product"/> by their category
        /// </summary>
        /// <param name="categoryId">Database identification of ID</param>
        /// <param name="cancellationToken">Cancellation Token</param>
        /// <returns>List of <see cref="Product"/> whose category matches sent categoryId</returns>
        /// <exception cref="DatabaseOperationException">Exception against database operations</exception>
        public async Task<IEnumerable<Product>> ListByCategoryAsync(int categoryId, CancellationToken cancellationToken = default)
        {
            try
            {
                return await _listByCategoryAsyncQuery(Context, categoryId, cancellationToken);
            }
            catch(Exception exception)
            {
                throw new DatabaseOperationException(exception.Message);
            }
        }
    }
}
