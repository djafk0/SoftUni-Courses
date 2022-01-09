using AutoMapper;
using ProductShop.Dtos.input;
using ProductShop.Dtos.UserInputDto;
using ProductShop.Models;

namespace ProductShop
{
    public class ProductShopProfile : Profile
    {
        public ProductShopProfile()
        {
            CreateMap<UserInputDto, User>();

            CreateMap<ProductInputDto, Product>();

            CreateMap<CategoryInputDto, Category>();

            CreateMap<CategoryProductsInputDto, CategoryProduct>();
        }
    }
}
