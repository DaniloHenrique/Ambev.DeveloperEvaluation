using Ambev.DeveloperEvaluation.Application.Carts;
using Ambev.DeveloperEvaluation.Application.Carts.UpdateCart;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Carts.UpdateCart
{
    public class UpdateCartProfile:Profile
    {
        public UpdateCartProfile()
        {
            CreateMap<UpdateCartItemRequest, UpdateCartItemCommand>();
            CreateMap<UpdateCartRequest, UpdateCartCommand>();
        }
    }
}
