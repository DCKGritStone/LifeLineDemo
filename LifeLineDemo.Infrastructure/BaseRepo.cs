using LifeLineDemo.Domain.Interface;
using LifeLineDemo.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace LifeLineDemo.Infrastructure
{
    public class BaseRepo<TEntity> : BaseRepo<TEntity, int>, IRepo<TEntity> where TEntity : class, IEntity<int>
    {
        public BaseRepo(LifeLineDbContext dbContext) : base(dbContext) { }


    }
    public class BaseRepo<TEntity, TPrimaryKey> : IRepo<TEntity, TPrimaryKey> where TEntity : class, IEntity<TPrimaryKey>
    {
        private readonly DbSet<TEntity> dbSet;
        private readonly LifeLineDbContext dbContext;

        public BaseRepo(LifeLineDbContext dbContext)
        {
            dbSet = dbContext.Set<TEntity>();
            this.dbContext = dbContext;
        }

        public async Task<TEntity> Create(TEntity entity)
        {
            dbContext.Set<TEntity>().Add(entity);
            await dbContext.SaveChangesAsync();
            return entity;
        }

        public async Task<long> Delete(long id)
        {
            var entity = await dbContext.Set<TEntity>().FindAsync(id);
            if (entity != null)
            {
                dbContext.Set<TEntity>().Remove(entity);
                return await dbContext.SaveChangesAsync();
            }
            return 0;
        }

        public async Task<long> Update(long id, TEntity entity)
        {
            dbContext.Set<TEntity>().Update(entity);
            return await dbContext.SaveChangesAsync();
        }
    }
    /* public class BaseRepo : IRepo
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
              model.SetProperty(z => z.FirstName, user.FirstName)
              .SetProperty(z=>z.LastName,user.LastName)
              .SetProperty(z=>z.AddressLine1, user.AddressLine1)
              .SetProperty(z=>z.AddressLine2, user.AddressLine2)
              .SetProperty(z=>z.Pincode, user.Pincode)
              .SetProperty(z=>z.Dob, user.Dob)
              .SetProperty(z=>z.Gender, user.Gender)
              .SetProperty(z => z.PhoneNumber, user.PhoneNumber)
              .SetProperty(z => z.Email, user.Email)
              .SetProperty(z=>z.BloodGroup, user.BloodGroup)
              .SetProperty(z=>z.LicenseNumber, user.LicenseNumber)
              .SetProperty(z=>z.LicenseExpiryDate, user.LicenseExpiryDate)
              .SetProperty(z => z.IsAvailable, user.IsAvailable)
              .SetProperty(z => z.RoleId, user.RoleId));
         }

         public async Task<long> UpdateUserRoles(long id, UserRoles userRoles)
         {
             return await dbContext.UserRoles.Where(y => y.Id == id).ExecuteUpdateAsync(model =>
             model.SetProperty(z => z.UserId, userRoles.UserId)
             .SetProperty(z => z.RoleId, userRoles.RoleId));
         }

         async Task<Hospital> IRepo.CreateHospital(Hospital hospital)
         {
             await dbContext.Hospitals.AddAsync(hospital);
             dbContext.SaveChanges();
             return hospital;
         }

         async Task<long> IRepo.DeleteHospital(long id)
         {
             return await dbContext.Hospitals.Where(l=>l.Id == id).ExecuteDeleteAsync();
         }

         async Task<long> IRepo.UpdateHospital(long id, Hospital hospital)
         {
              return await dbContext.Hospitals.Where(l=>l.Id==id).ExecuteUpdateAsync(setters=>setters
             .SetProperty(z=>z.Name, hospital.Name)
             .SetProperty(z=>z.Address, hospital.Address)
             .SetProperty(z=>z.City,hospital.City)
             .SetProperty(z=>z.AmbulanceCount,hospital.AmbulanceCount)
             .SetProperty(z=>z.PhoneNumber,hospital.PhoneNumber)
             .SetProperty(z=>z.State,hospital.State)
             .SetProperty(z=>z.Email,hospital.Email)
             .SetProperty(z=>z.Longitude,hospital.Longitude)
             .SetProperty(z=>z.Latitude,hospital.Latitude)
             .SetProperty(z=>z.EmergencyServicesAvailable,hospital.EmergencyServicesAvailable)
             .SetProperty(z=>z.Rating,hospital.Rating)
             .SetProperty(z=>z.Specializations,hospital.Specializations)
             .SetProperty(z=>z.ZipCode,hospital.ZipCode));


         }
     }*/
}
