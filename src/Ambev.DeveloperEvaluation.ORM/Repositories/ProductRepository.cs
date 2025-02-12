using Ambev.DeveloperEvaluation.Domain.CompiledQueries;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Ambev.DeveloperEvaluation.ORM.Repositories
{
    public class ProductRepository : CrudRepository<DefaultContext, Product, int>, IProductRepository
    {
        protected override DbSet<Product> GetDbSet => _context.Products;

        public ProductRepository(DefaultContext context):base(context){}

        private Task<Category?> GetCategoryByDescription(string description, CancellationToken cancellationToken=default)=>
            _context.Categories.FirstOrDefaultAsync(c => c.Description == description, cancellationToken);

        public override async Task<Product> CreateAsync(Product entity, CancellationToken cancellationToken = default)
        {
            var category = await GetCategoryByDescription(entity.Category.Description,cancellationToken);

            if (category is not null)
            {
                entity.Category = category;

                _context.Categories.Attach(entity.Category);
            }

            return await base.CreateAsync(entity, cancellationToken);
        }

        public Task<IEnumerable<Product>> ListByCategoryAsync(int categoryId, CancellationToken cancellationToken = default) =>
            Task.Run(()=>ProductCompiledQueries<DefaultContext>.ListProductByCategoryQuery(_context, categoryId));

        public Task<Product?> Get(int id) => _context
            .Products
            .Include(p => p.Category)
            .Include(p => p.Rating)
            .FirstOrDefaultAsync(p => p.Id == id);

        public override async Task<Product> UpdateAsync(Product entity, CancellationToken cancellationToken = default)
        {
            await _context
                .Products
                .Where(e => e.Id == entity.Id)
                .ExecuteUpdateAsync(product => product
                    .SetProperty(p => p.Price, entity.Price)
                    .SetProperty(p=>p.Description, entity.Description)
                    .SetProperty(p=>p.Title, entity.Title)
                    .SetProperty(p=>p.Image, entity.Image)
                    .SetProperty(p=>p.Price, entity.Price)  
                );

            return entity;
        }

    }
}
