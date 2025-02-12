using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Ambev.DeveloperEvaluation.ORM.Repositories
{
    public class CategoryRepository : CrudRepository<DefaultContext, Category, int>, ICategoryRepository
    {
        public CategoryRepository(DefaultContext context):base(context){}

        protected override DbSet<Category> GetDbSet => _context.Categories;

        public Task<Category?> GetByDescriptionAsync(string description, CancellationToken cancellationToken = default)=>
            _context.Categories.FirstOrDefaultAsync(c=>c.Description == description, cancellationToken);
    }
}
