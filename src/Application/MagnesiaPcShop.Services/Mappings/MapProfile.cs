using AutoMapper;
using MagnesiaPcShop.DataTransferObjects.Responses.Category;
using MagnesiaPcShop.DataTransferObjects.Responses.Product;
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
            CreateMap<Category, CategoryDisplayResponse>();
        }
    }
}
