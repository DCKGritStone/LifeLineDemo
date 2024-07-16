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
        private readonly IRepo repo;
        private readonly IMapper mapper;

        public UserRolesCommandHandler(IRepo repo, IMapper mapper)
        {
            this.repo = repo;
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
                    var createUserRoles = await repo.CreateUserRoles(userRoles);
                    return mapper.Map<UserRolesDto>(createUserRoles);

                case Operation.Update:

                    var updateUserRoles = new UserRoles
                    {
                        Id = request.UserRolesDto.Id,
                        UserId = request.UserRolesDto.UserId,
                        RoleId = request.UserRolesDto.RoleId
                    };
                    await repo.UpdateUserRoles(request.UserRolesDto.Id, updateUserRoles);
                    return mapper.Map<UserRolesDto>(updateUserRoles);

                case Operation.Delete:

                    await repo.DeleteUserRoles(request.UserRolesDto.Id);

                    return null;

                default:
                    throw new NotImplementedException();

            }
        }
    }
}
