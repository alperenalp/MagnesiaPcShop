using MagnesiaBilgisayar.Application.Services;
using MagnesiaPcShop.Infrastructure.Repositories;
using MagnesiaPcShop.Services.Mappings;
using MagnesiaPcShop.Services;
using MagnesiaPcShop.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace MagnesiaPcShop.Mvc.Extensions
{
    public static class InversionOfControlExtensions
    {
        public static WebApplicationBuilder AddInjections(this WebApplicationBuilder builder)
        {
            builder.Services.AddScoped<IProductService, ProductService>();
            builder.Services.AddScoped<IProductRepository, EFProductRepository>();
            builder.Services.AddScoped<ICategoryService, CategoryService>();
            builder.Services.AddScoped<ICategoryRepository, EFCategoryRepository>();
            builder.Services.AddScoped<IUserService, UserService>();
            builder.Services.AddScoped<IUserRepository, EFUserRepository>();

            builder.Services.AddAutoMapper(typeof(MapProfile));

            var connectionString = builder.Configuration.GetConnectionString("db");
            builder.Services.AddDbContext<MagnesiaPcDbContext>(opt => opt.UseSqlServer(connectionString));

            return builder;
        }
    }
}
