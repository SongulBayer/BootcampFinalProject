using AutoMapper;
using PycApi.Data;
using PycApi.Dto;

namespace PycApi.Mapper
{
    public class MappingProfile : Profile
    {
        //Mapps Created
        public MappingProfile()
        {
            CreateMap<AccountDto, Account>().ReverseMap();
            CreateMap<BrandDto, Brand>().ReverseMap();
            CreateMap<CategoryDto, Category>().ReverseMap();
            CreateMap<ColorDto, Color>().ReverseMap();
            CreateMap<OfferDto, Offer>().ReverseMap();
            CreateMap<ProductDto, Product>().ReverseMap();
        }

    }
}
