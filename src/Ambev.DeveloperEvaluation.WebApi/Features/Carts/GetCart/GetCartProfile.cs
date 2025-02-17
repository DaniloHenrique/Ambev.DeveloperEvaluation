using Ambev.DeveloperEvaluation.Application.Carts.GetCart;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Carts.GetCart
{
    public class GetCartProfile:Profile
    {
        public GetCartProfile():base()
        {
            CreateMap<GetCartRequest, GetCartQuery>();
            CreateMap<GetCartResult, GetCartResponse>();
        }
    }
}
