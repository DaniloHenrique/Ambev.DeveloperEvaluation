using Ambev.DeveloperEvaluation.Application.Products;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Product
{
    public class RatingProfile:Profile
    {
        public RatingProfile()
        {
            CreateMap<RatingRequest, RatingCommand>();
            CreateMap<RatingResult, RatingResponse>();
        }
    }
}
