using LifeLineDemo.Domain.DTO;
using LifeLineDemo.Domain.Enums;
using MediatR;

namespace LifeLineDemo.Application.Command.UserRole
{
    public class UserRolesCommand : IRequest<UserRolesDto>
    {
        public UserRolesCommand(Operation operation, UserRolesDto userRolesDto)
        {
            Operation = operation;
            UserRolesDto = userRolesDto;
        }
        public UserRolesCommand(Operation operation, UserRolesNoIdDto userRolesNoIdDto)
        {
            Operation = operation;
            UserRolesNoIdDto = userRolesNoIdDto;
        }
        public Operation Operation { get; }
        public UserRolesNoIdDto UserRolesNoIdDto { get; }
        public UserRolesDto UserRolesDto { get; }
    }
}
