using Ambev.DeveloperEvaluation.Domain.Common;

namespace Ambev.DeveloperEvaluation.Domain.Entities
{
    public class Category:BaseEntity<int>
    {

        public string Description { get; set; } = string.Empty;
        public List<Product> Products { get; set; } = [];
    }
}
