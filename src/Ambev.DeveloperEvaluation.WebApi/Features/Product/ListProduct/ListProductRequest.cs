namespace Ambev.DeveloperEvaluation.WebApi.Features.Product.ListProduct
{
    public class ListProductRequest
    {
        public ListProductRequest() { }
        public ListProductRequest(string category)
        {
            Category = category;
        }
        public string? Category { get; set; }
    }
}
