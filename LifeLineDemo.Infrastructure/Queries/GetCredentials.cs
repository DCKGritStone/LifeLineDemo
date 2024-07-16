using AutoMapper;
using LifeLineDemo.Domain.DTO;
using LifeLineDemo.Domain.Interface.Queries;
using LifeLineDemo.Infrastructure.Data;

namespace LifeLineDemo.Infrastructure.Queries
{
    public class GetCredentials : IGetCredentials
    {
        private readonly LifeLineDbContext dbContext;
        private readonly IMapper mapper;

        public GetCredentials(LifeLineDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        public IList<CredDto> GetAllCredentials()
        {
            return mapper.Map<IList<CredDto>>(dbContext.Credentials.ToList());
        }

        public CredDto GetCerdentialById(long id)
        {
            return mapper.Map<CredDto>(dbContext.Credentials.FirstOrDefault(x => x.Id == id));
        }
    }
}
