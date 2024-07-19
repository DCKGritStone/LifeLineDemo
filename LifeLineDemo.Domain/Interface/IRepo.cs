namespace LifeLineDemo.Domain.Interface
{
    public interface IRepo<TEntity> : IRepo<TEntity, int> where TEntity : class, IEntity<int>
    {
    }
    public interface IRepo<TEntity, TPrimaryKey> where TEntity : class, IEntity<TPrimaryKey>
    {
        Task<TEntity> Create(TEntity entity);
        Task<long> Update(long id, TEntity entity);
        Task<long> Delete(long id);
    }
    /* public interface IRepo
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

         Task<Hospital> CreateHospital(Hospital hospital);
         Task<long> UpdateHospital(long id, Hospital hospital);
         Task<long> DeleteHospital(long id);
     }*/
}
