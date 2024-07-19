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
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public RoleCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
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
                    var createRole = await unitOfWork._roleRepo.Create(role);
                    return mapper.Map<RoleDto>(createRole);

                case Operation.Update:

                    var updateRole = new Role
                    {
                        Id = request.RoleDto.Id,
                        RoleName = request.RoleDto.RoleName
                    };
                    await unitOfWork._roleRepo.Update(request.RoleDto.Id, updateRole);
                    return mapper.Map<RoleDto>(updateRole);

                case Operation.Delete:

                    await unitOfWork._roleRepo.Delete(request.RoleDto.Id);

                    return null;

                default:
                    throw new NotImplementedException();
            }
        }
    }
}
