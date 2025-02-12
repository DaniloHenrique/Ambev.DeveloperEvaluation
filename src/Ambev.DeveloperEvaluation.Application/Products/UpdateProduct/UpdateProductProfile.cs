using Ambev.DeveloperEvaluation.Application.Products.CreateProduct;
using Ambev.DeveloperEvaluation.Domain.Entities;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.Application.Products.UpdateProduct
{
    public class UpdateProductProfile:Profile
    {
        public UpdateProductProfile()
        {
            CreateMap<UpdateProductCommand, Product>()
                .ForMember(p => p.Category, c => c.MapFrom(cp => new Category { Description = cp.Category }));
            CreateMap<Product, UpdateProductResult>()
                .ForMember(cp => cp.Category, c => c.MapFrom(cp => cp.Category.Description));
        }
    }
}
