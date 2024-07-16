using AutoMapper;
using LifeLineDemo.Domain.DTO;
using LifeLineDemo.Domain.Entities;
using LifeLineDemo.Domain.Enums;
using LifeLineDemo.Domain.Interface;
using MediatR;

namespace LifeLineDemo.Application.Command.Credentail
{
    public class CredentialsCommandHandler : IRequestHandler<CredentialsCommand, CredDto>
    {
        private readonly IRepo repo;
        private readonly IMapper mapper;

        public CredentialsCommandHandler(IRepo repo, IMapper mapper)
        {
            this.repo = repo;
            this.mapper = mapper;
        }
        public async Task<CredDto> Handle(CredentialsCommand request, CancellationToken cancellationToken)
        {
            Credentials credentials;

            switch (request.Operation)
            {
                case Operation.Create:
                    credentials = new Credentials
                    {
                        Password = request.CredNoIdDto.Password,
                        PasswordKey = request.CredNoIdDto.PasswordKey,
                        UserId = request.CredNoIdDto.UserId
                    };
                    var createCredential = await repo.CreateCredentials(credentials);
                    return mapper.Map<CredDto>(createCredential);

                case Operation.Update:
                    var updateCredential = new Credentials
                    {
                        Id = request.CredDto.Id,
                        Password = request.CredNoIdDto.Password,
                        PasswordKey = request.CredNoIdDto.PasswordKey,
                        UserId = request.CredNoIdDto.UserId
                    };
                    await repo.UpdateCredentials(request.CredDto.Id, updateCredential);
                    return mapper.Map<CredDto>(updateCredential);

                case Operation.Delete:

                    await repo.DeleteCredentials(request.CredDto.Id);
                    return null;

                default:
                    throw new NotImplementedException();

            }
        }
    }
}
