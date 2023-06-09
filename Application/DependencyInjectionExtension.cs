using Application.Repositories;
using Application.Repositories.Interfaces;
using Application.Services;
using Application.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Application
{
    public static class DependencyInjectionExtension 
    {
        public static void AddApplication (this IServiceCollection services)
        {
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped<IProductRepository,ProductRepository>();
            services.AddScoped<IProductService,ProductService>();
        }
    }
}