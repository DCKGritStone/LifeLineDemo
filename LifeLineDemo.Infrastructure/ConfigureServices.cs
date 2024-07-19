using LifeLineDemo.Domain.Entities;
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

            services.AddScoped<IRepo<User, long>, BaseRepo<User, long>>();
            services.AddScoped<IRepo<UserRoles, long>, BaseRepo<UserRoles, long>>();
            services.AddScoped<IRepo<Role, long>, BaseRepo<Role, long>>();
            services.AddScoped<IRepo<Hospital, long>, BaseRepo<Hospital, long>>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IGetRole, GetRole>();
            services.AddScoped<IGetUser, GetUser>();
            services.AddScoped<IGetUserRoles, GetUserRole>();
            return services;
        }
    }
}
