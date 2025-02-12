using Ambev.DeveloperEvaluation.Domain.Entities;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.Application.Products
{
    public class RatingProfile : Profile
    {
        public RatingProfile()
        {
            CreateMap<RatingCommand, Rating>();
            CreateMap<Rating, RatingResult>();
        }
    }
}
