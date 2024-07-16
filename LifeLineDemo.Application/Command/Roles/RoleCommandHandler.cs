using AutoMapper;
using LifeLineDemo.Domain.DTO;
using LifeLineDemo.Domain.Entities;
using LifeLineDemo.Domain.Enums;
using LifeLineDemo.Domain.Interface;
using MediatR;

namespace LifeLineDemo.Application.Command.Roles
{


    public class RoleCommandHandler : IRequestHandler<RoleCommand, RoleDto>

    {
        private readonly IRepo repo;
        private readonly IMapper mapper;

        public RoleCommandHandler(IRepo repo, IMapper mapper)
        {
            this.repo = repo;
            this.mapper = mapper;
        }

        public async Task<RoleDto> Handle(RoleCommand request, CancellationToken cancellationToken)
        {
            Role role;

            switch (request.Operation)
            {
                case Operation.Create:
                    role = new Role
                    {
                        RoleName = request.RoleNoIdDto.RoleName
                    };
                    var createRole = await repo.CreateRole(role);
                    return mapper.Map<RoleDto>(createRole);

                case Operation.Update:

                    var updateRole = new Role
                    {
                        Id = request.RoleDto.Id,
                        RoleName = request.RoleDto.RoleName
                    };
                    await repo.UpdateRole(request.RoleDto.Id, updateRole);
                    return mapper.Map<RoleDto>(updateRole);

                case Operation.Delete:

                    await repo.DeleteRole(request.RoleDto.Id);

                    return null;

                default:
                    throw new NotImplementedException();
            }
        }
    }
}
