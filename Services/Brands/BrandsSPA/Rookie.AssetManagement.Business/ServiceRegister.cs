using Microsoft.Extensions.DependencyInjection;
using Services.Brands.BrandsSPA.Rookie.AssetManagement.Business.Interfaces;
using Services.Brands.BrandsSPA.Rookie.AssetManagement.Business.Services;
using System.Reflection;

namespace Services.Brands.BrandsSPA.Rookie.AssetManagement.Business
{
    public static class ServiceRegister
    {
        public static void AddBusinessLayer(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddTransient(typeof(IBaseRepository<>), typeof(BaseRepository<>));
            services.AddTransient<IBrandService, BrandService>();
        }
    }
}