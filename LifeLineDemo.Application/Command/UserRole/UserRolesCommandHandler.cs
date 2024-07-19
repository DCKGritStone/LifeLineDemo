using AutoMapper;
using LifeLineDemo.Domain.DTO;
using LifeLineDemo.Domain.Entities;
using LifeLineDemo.Domain.Enums;
using LifeLineDemo.Domain.Interface;
using MediatR;

namespace LifeLineDemo.Application.Command.UserRole
{
    public class UserRolesCommandHandler : IRequestHandler<UserRolesCommand, UserRolesDto>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public UserRolesCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public async Task<UserRolesDto> Handle(UserRolesCommand request, CancellationToken cancellationToken)
        {
            UserRoles userRoles;

            switch (request.Operation)
            {
                case Operation.Create:
                    userRoles = new UserRoles
                    {
                        UserId = request.UserRolesNoIdDto.UserId,
                        RoleId = request.UserRolesNoIdDto.RoleId
                    };
                    var createUserRoles = await unitOfWork._userRoleRepo.Create(userRoles);
                    return mapper.Map<UserRolesDto>(createUserRoles);

                case Operation.Update:

                    var updateUserRoles = new UserRoles
                    {
                        Id = request.UserRolesDto.Id,
                        UserId = request.UserRolesDto.UserId,
                        RoleId = request.UserRolesDto.RoleId
                    };
                    await unitOfWork._userRoleRepo.Update(request.UserRolesDto.Id, updateUserRoles);
                    return mapper.Map<UserRolesDto>(updateUserRoles);

                case Operation.Delete:

                    await unitOfWork._userRoleRepo.Delete(request.UserRolesDto.Id);

                    return null;

                default:
                    throw new NotImplementedException();

            }
        }
    }
}
