using Application.Interfaces;
using Infrastructure.Context;
using Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure
{
    public static class ServiceCollectionExtension
    {
        public static void RegisterServices(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration["ConnectionStrings:DefaultConnection"];
            if (string.IsNullOrEmpty(connectionString)) throw new Exception("Connection string not found.");


            services.AddDbContext<AppDbContext>(o => o.UseSqlite(connectionString));

            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }
    }
}
