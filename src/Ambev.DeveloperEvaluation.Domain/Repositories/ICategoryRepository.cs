using Ambev.DeveloperEvaluation.Domain.Common;
using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.Domain.Repositories
{
    public interface ICategoryRepository:ICrudRepository<Category,int>
    {
        Task<Category?> GetByDescriptionAsync(string description,CancellationToken cancellationToken=default);
    }
}
