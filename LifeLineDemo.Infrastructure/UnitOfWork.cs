using LifeLineDemo.Domain.Entities;
using LifeLineDemo.Domain.Interface;
using LifeLineDemo.Infrastructure.Data;

namespace LifeLineDemo.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly LifeLineDbContext dbContext;


        public UnitOfWork(LifeLineDbContext dbContext, IRepo<User, long> userRepo,
        IRepo<UserRoles, long> userRoleRepo,
        IRepo<Role, long> roleRepo,
        IRepo<Hospital, long> hospitalRepo)
        {
            this.dbContext = dbContext;
            UserRepo = userRepo;
            UserRoleRepo = userRoleRepo;
            RoleRepo = roleRepo;
            HospitalRepo = hospitalRepo;
        }

        public IRepo<User, long> UserRepo { get; }
        public IRepo<UserRoles, long> UserRoleRepo { get; }
        public IRepo<Role, long> RoleRepo { get; }
        public IRepo<Hospital, long> HospitalRepo { get; }

        public IRepo<User, long> _userRepo => UserRepo;
        public IRepo<UserRoles, long> _userRoleRepo => UserRoleRepo;
        public IRepo<Role, long> _roleRepo => RoleRepo;
        public IRepo<Hospital, long> _hospitalRepo => HospitalRepo;


        /*public async Task BeginTransactionAsync()
        {
            await dbContext.Database.BeginTransactionAsync();
        }

        public async Task CommitTransactionAsync()
        {
            await dbContext.Database.CommitTransactionAsync();
        }

        public async Task RollbackTransactionAsync()
        {
            await dbContext.Database.RollbackTransactionAsync();
        }

        public async Task<int> SaveChangesAsync()
        {
            var result = await dbContext.SaveChangesAsync();
            return result;
        }*/
    }
}
