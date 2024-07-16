using LifeLineDemo.Domain.Interface;
using LifeLineDemo.Domain.Interface.Queries;
using LifeLineDemo.Infrastructure.Data;
using LifeLineDemo.Infrastructure.Queries;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace LifeLineDemo.Infrastructure
{
    public static class ConfigureServices
    {
        public static IServiceCollection InfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<LifeLineDbContext>(option => option.UseSqlServer(configuration.GetConnectionString("LifeLineConnection")));

            services.AddScoped<IRepo, BaseRepo>();
            services.AddScoped<IGetRole, GetRole>();
            services.AddScoped<IGetUser, GetUser>();
            services.AddScoped<IGetUserRoles, GetUserRole>();
            services.AddScoped<IGetCredentials, GetCredentials>();
            return services;
        }
    }
}
