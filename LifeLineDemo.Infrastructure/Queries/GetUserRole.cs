using AutoMapper;
using LifeLineDemo.Domain.DTO;
using LifeLineDemo.Domain.Interface.Queries;
using LifeLineDemo.Infrastructure.Data;

namespace LifeLineDemo.Infrastructure.Queries
{
    public class GetUserRole : IGetUserRoles
    {
        private readonly LifeLineDbContext dbContext;
        private readonly IMapper mapper;

        public GetUserRole(LifeLineDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        public IList<UserRolesDto> GetAllUserRoles()
        {
            return mapper.Map<IList<UserRolesDto>>(dbContext.UserRoles.ToList());
        }

        public UserRolesDto GetUserRoleById(long id)
        {
            return mapper.Map<UserRolesDto>(dbContext.UserRoles.FirstOrDefault(x => x.Id == id));
        }
    }
}
