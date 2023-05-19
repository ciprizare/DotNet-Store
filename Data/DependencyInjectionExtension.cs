using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Data
{
    public static class DependencyInjectionExtension
    {
        public static void AddDataContext(this IServiceCollection services, IConfiguration config) {
            services.AddDbContext<DataContext>(options=>options.UseSqlite(config.GetConnectionString("DefaultConnection")));
            services.AddScoped<IDataContext>(provider => provider.GetService<DataContext>());
        }
    }
}