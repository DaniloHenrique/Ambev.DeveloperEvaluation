using Ambev.DeveloperEvaluation.Domain.Entities;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.Application.Products.GetProduct
{
    public class GetProductProfile:Profile
    {
        public GetProductProfile()
        {
            CreateMap<Product, GetProductResult>()
                .ForMember(p=>p.Category,c=>c.MapFrom(r=>r.Category.Description));
        }
    }
}
