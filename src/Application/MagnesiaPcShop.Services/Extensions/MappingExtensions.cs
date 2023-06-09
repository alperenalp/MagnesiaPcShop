using AutoMapper;
using MagnesiaPcShop.DataTransferObjects.Requests.Product;
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

        public static T ConvertToDto<T>(this Product product, IMapper mapper)
        {
            return mapper.Map<T>(product);
        }

        public static Product ConvertToProduct<T>(this T request, IMapper mapper)
        {
            return mapper.Map<Product>(request);
        }


        public static T ConvertToDto<T>(this IEnumerable<Category> categories, IMapper mapper)
        {
            return mapper.Map<T>(categories);
        }

        public static T ConvertToDto<T>(this Category category, IMapper mapper)
        {
            return mapper.Map<T>(category);
        }

        public static Category ConvertToCategory<T>(this T request, IMapper mapper)
        {
            return mapper.Map<Category>(request);
        }


        public static T ConvertToDto<T>(this User user, IMapper mapper)
        {
            return mapper.Map<T>(user);
        }
        public static User ConvertToUser<T>(this T request, IMapper mapper)
        {
            return mapper.Map<User>(request);
        }
    }
}
