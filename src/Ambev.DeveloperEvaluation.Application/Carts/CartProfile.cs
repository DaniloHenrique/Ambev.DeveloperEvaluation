using Ambev.DeveloperEvaluation.Domain.Entities;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.Application.Carts
{
    public class CartProfile : Profile
    {
        public CartProfile()
        {
            CreateMap<CartItemCommand, CartItem>()
                .ForMember(entity => entity.ProductId, c => c.MapFrom(command => command.ProductId));
            CreateMap<UserCommand, User>();
            CreateMap<Product, ProductResult>()
                .ForMember(result => result.Name, c => c.MapFrom(entity => entity.Title));
            CreateMap<CartItem, CartItemResult>();
            CreateMap<User, UserResult>()
                .ForMember(result => result.Name, c => c.MapFrom(entity => entity.Username));

        }
    }
}
