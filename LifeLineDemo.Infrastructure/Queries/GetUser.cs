using AutoMapper;
using LifeLineDemo.Domain.DTO;
using LifeLineDemo.Domain.Interface.Queries;
using LifeLineDemo.Infrastructure.Data;

namespace LifeLineDemo.Infrastructure.Queries
{
    public class GetUser : IGetUser
    {
        private readonly LifeLineDbContext dbContext;
        private readonly IMapper mapper;

        public GetUser(LifeLineDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        public IList<UserDto> GetAllUsers()
        {
            return mapper.Map<IList<UserDto>>(dbContext.Users.ToList());
        }

        public UserDto GetUserById(long id)
        {
            return mapper.Map<UserDto>(dbContext.Users.FirstOrDefault(x => x.Id == id));
        }
    }
}
