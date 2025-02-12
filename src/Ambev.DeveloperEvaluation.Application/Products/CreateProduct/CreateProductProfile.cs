using Ambev.DeveloperEvaluation.Domain.Entities;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.Application.Products.CreateProduct
{
    public class CreateProductProfile:Profile
    {
        public CreateProductProfile()
        {
            CreateMap<CreateProductCommand, Product>()
                .ForMember(p=>p.Category,c=>c.MapFrom(cp=>new Category { Description = cp.Category }));
            CreateMap<Product, CreateProductResult>()
                .ForMember(cp => cp.Category, c => c.MapFrom(cp => cp.Category.Description));
        }
    }
}
