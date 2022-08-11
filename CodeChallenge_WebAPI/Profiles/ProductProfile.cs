using AutoMapper;
using DB.Models;
using Services.ViewModels;

namespace CodeChallenge_WebAPI.Profiles
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<ProductRequest, Product>();
        }
    }
}
