using LifeLineDemo.Domain.DTO;
using LifeLineDemo.Domain.Enums;
using MediatR;

namespace LifeLineDemo.Application.Command.Roles
{
    public class RoleCommand : IRequest<RoleDto>
    {
        public RoleCommand(Operation operation, RoleDto roleDto)
        {
            Operation = operation;
            RoleDto = roleDto;
        }
        public RoleCommand(Operation operation, RoleNoIdDto roleNoIdDto)
        {
            Operation = operation;
            RoleNoIdDto = roleNoIdDto;
        }
        public Operation Operation { get; }
        public RoleNoIdDto RoleNoIdDto { get; }
        public RoleDto RoleDto { get; }
    }
}
