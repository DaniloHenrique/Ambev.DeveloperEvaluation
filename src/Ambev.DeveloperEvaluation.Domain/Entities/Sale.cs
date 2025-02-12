using Ambev.DeveloperEvaluation.Domain.Common;

namespace Ambev.DeveloperEvaluation.Domain.Entities
{
    public class Sale:BaseEntity<int>
    {
        public Sale() 
        {
            Branch = new Branch();
            Cart = new Cart();  
        }

        public Branch Branch { get; set; }  
        public int BranchId { get=>Branch.Id; set=>Branch.Id = value; }   
        public Cart Cart { get; set; }
        public int CartId { get=>Cart.Id; set=>Cart.Id = value; }
        
    }
}
