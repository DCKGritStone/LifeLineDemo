using LifeLineDemo.Domain.DTO;

namespace LifeLineDemo.Domain.Interface.Queries
{
    public interface IGetHospital
    {
        IList<HospitalDto> GetHospitalList();
        HospitalDto GetHospitalById(long id);
    }
}
