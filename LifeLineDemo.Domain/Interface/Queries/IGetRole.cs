using LifeLineDemo.Domain.DTO;

namespace LifeLineDemo.Domain.Interface.Queries
{
    public interface IGetRole
    {
        IList<RoleDto> GetAllRoles();
        RoleDto GetRoleById(long id);
    }
}
