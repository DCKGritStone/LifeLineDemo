using LifeLineDemo.Domain.Entities;
using LifeLineDemo.Domain.Interface;
using LifeLineDemo.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace LifeLineDemo.Infrastructure
{
    public class BaseRepo : IRepo
    {
        private readonly LifeLineDbContext dbContext;

        public BaseRepo(LifeLineDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<Credentials> CreateCredentials(Credentials credentials)
        {

            await dbContext.Credentials.AddAsync(credentials);
            await dbContext.SaveChangesAsync();
            return credentials;
        }

        public async Task<Role> CreateRole(Role role)
        {
            await dbContext.Roles.AddAsync(role);
            await dbContext.SaveChangesAsync();
            return role;
        }

        public async Task<User> CreateUser(User user)
        {
            await dbContext.Users.AddAsync(user);
            await dbContext.SaveChangesAsync();
            return user;
        }

        public async Task<UserRoles> CreateUserRoles(UserRoles userRoles)
        {
            await dbContext.UserRoles.AddAsync(userRoles);
            await dbContext.SaveChangesAsync();
            return userRoles;
        }

        public async Task<long> DeleteCredentials(long id)
        {
            return await dbContext.Credentials.Where(x => x.Id == id).ExecuteDeleteAsync();
        }

        public async Task<long> DeleteRole(long id)
        {
            return await dbContext.Roles.Where(x => x.Id == id).ExecuteDeleteAsync();
        }

        public async Task<long> DeleteUser(long id)
        {
            return await dbContext.Users.Where(x => x.Id == id).ExecuteDeleteAsync();
        }

        public async Task<long> DeleteUserRoles(long id)
        {
            return await dbContext.UserRoles.Where(x => x.Id == id).ExecuteDeleteAsync();
        }

        public async Task<long> UpdateCredentials(long id, Credentials credentials)
        {
            return await dbContext.Credentials.Where(y => y.Id == id).ExecuteUpdateAsync(model =>
             model.SetProperty(z => z.Password, credentials.Password)
             .SetProperty(z => z.PasswordKey, credentials.PasswordKey)
             .SetProperty(z => z.UserId, credentials.UserId));
        }

        public async Task<long> UpdateRole(long id, Role role)
        {
            return await dbContext.Roles.Where(y => y.Id == id).ExecuteUpdateAsync(model =>
            model.SetProperty(z => z.RoleName, role.RoleName));
        }

        public async Task<long> UpdateUser(long id, User user)
        {
            return await dbContext.Users.Where(y => y.Id == id).ExecuteUpdateAsync(model =>
             model.SetProperty(z => z.UserName, user.UserName)
             .SetProperty(z => z.PhoneNumber, user.PhoneNumber)
             .SetProperty(z => z.Email, user.Email)
             .SetProperty(z => z.RoleId, user.RoleId));
        }

        public async Task<long> UpdateUserRoles(long id, UserRoles userRoles)
        {
            return await dbContext.UserRoles.Where(y => y.Id == id).ExecuteUpdateAsync(model =>
            model.SetProperty(z => z.UserId, userRoles.UserId)
            .SetProperty(z => z.RoleId, userRoles.RoleId));
        }
    }
}
