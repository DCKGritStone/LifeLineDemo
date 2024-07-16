using LifeLineDemo.Domain.DTO;

namespace LifeLineDemo.Domain.Interface.Queries
{
    public interface IGetCredentials
    {
        IList<CredDto> GetAllCredentials();
        CredDto GetCerdentialById(long id);
    }
}
