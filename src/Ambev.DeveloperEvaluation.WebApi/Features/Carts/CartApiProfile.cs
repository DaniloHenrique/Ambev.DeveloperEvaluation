using Ambev.DeveloperEvaluation.Application.Carts;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Carts
{
    public class CartApiProfile:Profile
    {
        public CartApiProfile() 
        {
            CreateMap<CartItemRequest, CartItemCommand>();
            CreateMap<CartItemResult, CartItemResponse>();
            CreateMap<ProductResult, ProductResponse>();
            CreateMap<UserRequest, UserCommand>();
            CreateMap<UserResult,UserResponse>();
        }
    }
}
