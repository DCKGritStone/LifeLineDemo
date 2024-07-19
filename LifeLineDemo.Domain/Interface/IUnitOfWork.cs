using LifeLineDemo.Domain.Entities;

namespace LifeLineDemo.Domain.Interface
{
    public interface IUnitOfWork
    {
        IRepo<User, long> _userRepo { get; }
        IRepo<UserRoles, long> _userRoleRepo { get; }
        IRepo<Role, long> _roleRepo { get; }
        IRepo<Hospital, long> _hospitalRepo { get; }
        /*Task BeginTransactionAsync();
        Task CommitTransactionAsync();
        Task RollbackTransactionAsync();
        Task<int> SaveChangesAsync();*/
    }
}
