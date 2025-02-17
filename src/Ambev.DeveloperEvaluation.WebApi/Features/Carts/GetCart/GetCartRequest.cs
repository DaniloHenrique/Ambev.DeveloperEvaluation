namespace Ambev.DeveloperEvaluation.WebApi.Features.Carts.GetCart
{
    public class GetCartRequest
    {
        public GetCartRequest(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
