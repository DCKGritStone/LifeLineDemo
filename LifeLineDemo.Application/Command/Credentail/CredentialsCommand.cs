using LifeLineDemo.Domain.DTO;
using LifeLineDemo.Domain.Enums;
using MediatR;

namespace LifeLineDemo.Application.Command.Credentail
{
    public class CredentialsCommand : IRequest<CredDto>
    {
        public CredentialsCommand(Operation operation, CredDto credDto)
        {
            Operation = operation;
            CredDto = credDto;
        }
        public CredentialsCommand(Operation operation, CredNoIdDto credNoIdDto)
        {
            Operation = operation;
            CredNoIdDto = credNoIdDto;
        }
        public Operation Operation { get; }
        public CredNoIdDto CredNoIdDto { get; }
        public CredDto CredDto { get; }
    }
}
