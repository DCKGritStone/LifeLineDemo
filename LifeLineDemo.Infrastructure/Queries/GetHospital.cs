using AutoMapper;
using LifeLineDemo.Domain.DTO;
using LifeLineDemo.Domain.Interface.Queries;
using LifeLineDemo.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LifeLineDemo.Infrastructure.Queries
{
    public class GetHospital : IGetHospital
    {
        private readonly LifeLineDbContext lifeLineDb;
        private readonly IMapper mapper;

        public GetHospital(LifeLineDbContext lifeLineDb,IMapper mapper)
        {
            this.lifeLineDb = lifeLineDb;
            this.mapper = mapper;
        }
        public HospitalDto GetHospitalById(int id)
        {
            var hospital = lifeLineDb.Hospitals.FirstOrDefault(x => x.Id == id);
            return mapper.Map<HospitalDto>(hospital);
        }

        public IList<HospitalDto> GetHospitalList()
        {
            var hospitallist=lifeLineDb.Hospitals.ToList();
            return mapper.Map<IList<HospitalDto>>(hospitallist);
        }
    }
}
