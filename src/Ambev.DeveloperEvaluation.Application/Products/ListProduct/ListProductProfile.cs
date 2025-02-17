using Ambev.DeveloperEvaluation.Application.Products.GetProduct;
using Ambev.DeveloperEvaluation.Domain.Entities;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.Application.Products.ListProduct
{
    public class ListProductProfile:Profile
    {
        public ListProductProfile()
        {
            CreateMap<Product, ListProductResult>()
                .ForMember(p => p.Category, c => c.MapFrom(r => r.Category.Description));
        }
    }
}
