using AutoMapper;
using ProductShop.Datasets.DtoModels.Input;
using ProductShop.Models;

namespace ProductShop
{
    public class ProductShopProfile : Profile
    {
        public ProductShopProfile()
        {
            this.CreateMap<UserInputDto, User>();
            this.CreateMap<ProductInputDto, Product>();
            this.CreateMap<CategoryInputDto, Category>();
            this.CreateMap<CategoryProductInputDto, CategoryProduct>();

        }
    }
}
