using Ambev.DeveloperEvaluation.Domain.Common;

namespace Ambev.DeveloperEvaluation.Domain.Entities
{
    public class Category:BaseIdentityEntity
    {
        public Category() { }
        public Category(string description) 
        {
            Description = description;
        }
        public string Description { get; set; } = string.Empty;
        public ICollection<Product> Products { get; set; } = [];
    }
}
