using LifeLineDemo.Domain.Entities;

namespace LifeLineDemo.Domain.Interface
{
    public interface IRepo
    {
        Task<User> CreateUser(User user);
        Task<long> UpdateUser(long id, User user);
        Task<long> DeleteUser(long id);

        Task<UserRoles> CreateUserRoles(UserRoles userRoles);
        Task<long> UpdateUserRoles(long id, UserRoles userRoles);
        Task<long> DeleteUserRoles(long id);

        Task<Role> CreateRole(Role role);
        Task<long> UpdateRole(long id, Role role);
        Task<long> DeleteRole(long id);

        Task<Credentials> CreateCredentials(Credentials credentials);
        Task<long> UpdateCredentials(long id, Credentials credentials);
        Task<long> DeleteCredentials(long id);
    }
}
