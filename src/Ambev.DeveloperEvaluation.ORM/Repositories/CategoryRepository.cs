using Ambev.DeveloperEvaluation.Domain.CompiledQueries;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Exceptions;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Ambev.DeveloperEvaluation.ORM.Repositories
{
    /// <summary>
    /// Database repository that handles operations over <see cref="Category"/> entity
    /// </summary>
    public class CategoryRepository : CrudRepository<DefaultContext, Category, int>, ICategoryRepository
    {
        /// <summary>
        /// Creates an instance of <see cref="CategoryRepository"/>
        /// </summary>
        /// <param name="context">Default Context of database</param>
        public CategoryRepository(DefaultContext context) : base(context){}

        /// <summary>
        /// Get a <see cref="Category"/> by its description
        /// </summary>
        /// <param name="description">Description of category to be searched</param>
        /// <param name="cancellationToken">Cancellation Token</param>
        /// <returns><see cref="Category"/> who matches sent description</returns>
        /// <exception cref="DatabaseOperationException">Exception against database operation</exception>
        public Task<Category?> GetByDescriptionAsync(string description, CancellationToken cancellationToken = default)
        {
            try
            {
                return Context
                    .Categories
                    .FirstOrDefaultAsync(categories => categories.Description == description, cancellationToken);
            }
            catch (Exception exception) 
            {
                throw new DatabaseOperationException(exception.Message);
            }
        }
    }
}
