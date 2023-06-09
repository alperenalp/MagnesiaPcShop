using AutoMapper;
using MagnesiaPcShop.DataTransferObjects.Requests.Category;
using MagnesiaPcShop.DataTransferObjects.Requests.Product;
using MagnesiaPcShop.DataTransferObjects.Requests.User;
using MagnesiaPcShop.DataTransferObjects.Responses.Category;
using MagnesiaPcShop.DataTransferObjects.Responses.Product;
using MagnesiaPcShop.DataTransferObjects.Responses.User;
using MagnesiaPcShop.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagnesiaPcShop.Services.Mappings
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<Product, ProductDisplayResponse>();
            CreateMap<Product, CreateNewProductRequest>().ReverseMap();
            CreateMap<Product, UpdateProductRequest>().ReverseMap();

            CreateMap<Category, CategoryDisplayResponse>();
            CreateMap<Category, CreateNewCategoryRequest>().ReverseMap();
            CreateMap<Category, UpdateCategoryRequest>().ReverseMap();

            CreateMap<User, UserValidateResponse>();
            CreateMap<User, CreateNewUserRequest>().ReverseMap();

        }
    }
}
