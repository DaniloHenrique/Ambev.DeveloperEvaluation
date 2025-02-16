using Ambev.DeveloperEvaluation.Domain.CompiledQueries;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Exceptions;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using ErrorOr;

namespace Ambev.DeveloperEvaluation.ORM.Repositories
{
    public class CategoryRepository : CrudRepository<DefaultContext, Category, int>, ICategoryRepository
    {
        private static string DescriptionNotFound = "Category {0} not found";

        Func<DefaultContext, string, CancellationToken,Task<Category?>> _getByDescriptionQuery;
        public CategoryRepository(DefaultContext context) : base(context)
        {
            _getByDescriptionQuery = CategoryCompiledQueries<DefaultContext>.GetByCategory;
        }

        public async Task<Category> GetByDescriptionAsync(string description, CancellationToken cancellationToken = default)
        {
            try
            {
                var found = await _getByDescriptionQuery(Context, description, cancellationToken);

                if (found is not null) return found;

                var message = string.Format(DescriptionNotFound, description);

                throw new RecordNotFoundException(message);
            }
            catch (RecordNotFoundException recordNotFoundException)
            {
                InvalidOperationException invalidOperationException = recordNotFoundException;

                throw invalidOperationException;
            }
            catch (Exception exception) 
            {
                throw new DatabaseOperationException(exception.Message);
            }
        }
    }
}
