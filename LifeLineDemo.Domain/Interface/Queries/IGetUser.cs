using LifeLineDemo.Domain.DTO;

namespace LifeLineDemo.Domain.Interface.Queries
{
    public interface IGetUser
    {
        IList<UserDto> GetAllUsers();
        UserDto GetUserById(long id);
    }
}
