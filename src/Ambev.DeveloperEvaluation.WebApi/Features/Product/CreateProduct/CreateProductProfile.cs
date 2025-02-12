using Ambev.DeveloperEvaluation.Application.Products.CreateProduct;
using AutoMapper;
using MediatR;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Product.CreateProduct
{
    public class CreateProductProfile:Profile
    {
        public CreateProductProfile() 
        {
            CreateMap<CreateProductRequest, CreateProductCommand>();
            CreateMap<CreateProductResult, CreateProductResponse>();
        }
    }
}
