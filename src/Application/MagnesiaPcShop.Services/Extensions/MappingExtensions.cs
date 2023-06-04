using AutoMapper;
using MagnesiaPcShop.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagnesiaPcShop.Services.Extensions
{
    public static class MappingExtensions
    {
        public static T ConvertToDto<T>(this IEnumerable<Product> products, IMapper mapper)
        {
            return mapper.Map<T>(products);
        }

        public static T ConvertToDto<T>(this IEnumerable<Category> categories, IMapper mapper)
        {
            return mapper.Map<T>(categories);
        }

        public static T ConvertToDto<T>(this Product product, IMapper mapper)
        {
            return mapper.Map<T>(product);
        }
    }
}
