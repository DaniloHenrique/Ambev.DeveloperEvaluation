using Ambev.DeveloperEvaluation.Domain.CompiledQueries;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Exceptions;
using Ambev.DeveloperEvaluation.Domain.Repositories;
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
                return await Context.Products
                    .Include(p => p.Rating)
                    .Where(p => p.Category.Id == categoryId)
                    .ToArrayAsync(cancellationToken);
            }
            catch(Exception exception)
            {
                throw new DatabaseOperationException(exception.Message);
            }
        }

        /// <summary>
        /// Retrieves all <see cref="Product"/> found
        /// </summary>
        /// <param name="cancellationToken">Cancellation Token</param>
        /// <returns>List of <see cref="Product"/></returns>
        public override async Task<IEnumerable<Product>> ListAsync(CancellationToken cancellationToken) =>
           await Context.Products
                .Include(p => p.Rating)
                .Include(p => p.Category)
                .ToArrayAsync(cancellationToken);

        /// <summary>
        /// Retrieves a <see cref="Product"/> by its database identification
        /// </summary>
        /// <param name="id">Database identification</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns><see cref="Product"/> or null</returns>
        public override Task<Product?> GetByIdAsync(int id, CancellationToken cancellationToken=default)=>
            Context.Products
                .Include(p => p.Category)
                .Include(p => p.Rating)
                .FirstOrDefaultAsync(p => p.Id == id,cancellationToken);
    }
}
