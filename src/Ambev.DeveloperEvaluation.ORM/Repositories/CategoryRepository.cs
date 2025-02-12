using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Net.Http.Headers;

namespace Ambev.DeveloperEvaluation.ORM.Repositories
{
    public class CategoryRepository : CrudRepository<DefaultContext, Category, int>, ICategoryRepository
    {
        public CategoryRepository(DefaultContext context):base(context){}

        protected override DbSet<Category> GetDbSet => _context.Categories;

        public Task<Category?> GetByDescriptionAsync(string description, CancellationToken cancellationToken = default)=>
            _context.Categories.FirstOrDefaultAsync(c=>c.Description == description, cancellationToken);

        public override async Task<Category> UpdateAsync(Category entity, CancellationToken cancellationToken = default)
        {
            await _context
                .Categories
                .Where(e => e.Id == entity.Id)
                .ExecuteUpdateAsync(category => category
                    .SetProperty(c => c.Description, entity.Description),
                    cancellationToken
                );

            return entity;
        }
    }
}
