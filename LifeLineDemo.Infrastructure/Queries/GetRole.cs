using AutoMapper;
using LifeLineDemo.Domain.DTO;
using LifeLineDemo.Domain.Interface.Queries;
using LifeLineDemo.Infrastructure.Data;

namespace LifeLineDemo.Infrastructure.Queries
{
    public class GetRole : IGetRole
    {
        private readonly LifeLineDbContext dbContext;
        private readonly IMapper mapper;

        public GetRole(LifeLineDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        public IList<RoleDto> GetAllRoles()
        {
            return mapper.Map<IList<RoleDto>>(dbContext.Roles.ToList());
        }

        public RoleDto GetRoleById(long id)
        {
            return mapper.Map<RoleDto>(dbContext.Roles.FirstOrDefault(x => x.Id == id));
        }
    }
}
