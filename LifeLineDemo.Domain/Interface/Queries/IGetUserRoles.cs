using LifeLineDemo.Domain.DTO;

namespace LifeLineDemo.Domain.Interface.Queries
{
    public interface IGetUserRoles
    {
        IList<UserRolesDto> GetAllUserRoles();
        UserRolesDto GetUserRoleById(long id);
    }
}
