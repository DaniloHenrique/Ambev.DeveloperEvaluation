using Ambev.DeveloperEvaluation.Domain.Common;

namespace Ambev.DeveloperEvaluation.Domain.Entities
{
    public class Sale:BaseIdentityEntity
    {
        public Branch Branch { get; set; } = null!; 
        public int BranchId { get; set; }   
        public Cart Cart { get; set; } = null!;
        public int CartId { get; set; }
        
    }
}
