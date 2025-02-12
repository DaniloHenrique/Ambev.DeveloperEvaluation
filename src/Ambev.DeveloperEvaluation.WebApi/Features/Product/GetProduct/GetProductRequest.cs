namespace Ambev.DeveloperEvaluation.WebApi.Features.Product.GetProduct
{
    public class GetProductRequest
    {
        public GetProductRequest() { }
        public GetProductRequest(int id)
        {
            Id = id; 
        }

        public int Id { get; set; }
    }
}
