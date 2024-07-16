using LifeLineDemo.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace LifeLineDemo.Infrastructure.Data
{
    public class LifeLineDbContext : DbContext
    {
        public LifeLineDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Role> Roles { get; set; }
        public DbSet<UserRoles> UserRoles { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Credentials> Credentials { get; set; }
    }
}
