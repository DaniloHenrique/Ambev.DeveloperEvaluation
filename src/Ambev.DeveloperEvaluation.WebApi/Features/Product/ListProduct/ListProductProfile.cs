using Ambev.DeveloperEvaluation.Application.Products.ListProduct;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Product.ListProduct
{
    public class ListProductProfile:Profile
    {
        public ListProductProfile()
        {
            CreateMap<ListProductRequest, ListProductQuery>();
            CreateMap<ListProductResult, ListProductResponse>();
        }
    }
}
