using LifeLineDemo.Domain.DTO;
using LifeLineDemo.Domain.Enums;
using MediatR;

namespace LifeLineDemo.Application.Command.Users
{
    public class UserCommand : IRequest<UserDto>
    {
        public UserCommand(Operation operation, UserDto userDto)
        {
            Operation = operation;
            UserDto = userDto;
        }
        public UserCommand(Operation operation, UserNoIdDto userNoIdDto)
        {
            Operation = operation;
            UserNoIdDto = userNoIdDto;
        }
        public Operation Operation { get; }
        public UserNoIdDto UserNoIdDto { get; }
        public UserDto UserDto { get; }
    }
}
