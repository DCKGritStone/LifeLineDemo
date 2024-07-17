using AutoMapper;
using LifeLineDemo.Domain.DTO;
using LifeLineDemo.Domain.Entities;
using LifeLineDemo.Domain.Enums;
using LifeLineDemo.Domain.Interface;
using MediatR;

namespace LifeLineDemo.Application.Command.Users
{
    public class UserCommandHandler : IRequestHandler<UserCommand, UserDto>
    {
        private readonly IRepo repo;
        private readonly IMapper mapper;

        public UserCommandHandler(IRepo repo, IMapper mapper)
        {
            this.repo = repo;
            this.mapper = mapper;
        }

        public async Task<UserDto> Handle(UserCommand request, CancellationToken cancellationToken)
        {
            User user;

            switch (request.Operation)
            {
                case Operation.Create:
                    user = new User
                    {
                        FirstName=request.UserNoIdDto
                        PhoneNumber = request.UserNoIdDto.PhoneNumber,
                        Email = request.UserNoIdDto.Email,
                        RoleId = request.UserNoIdDto.RoleId
                    };
                    var createUsers = await repo.CreateUser(user);
                    return mapper.Map<UserDto>(createUsers);

                case Operation.Update:

                    var updateUser = new User
                    {
                        Id = request.UserDto.Id,
                        PhoneNumber = request.UserDto.PhoneNumber,
                        Email = request.UserDto.Email,
                        RoleId = request.UserDto.RoleId
                    };
                    await repo.UpdateUser(request.UserDto.Id, updateUser);
                    return mapper.Map<UserDto>(updateUser);

                case Operation.Delete:

                    await repo.DeleteUser(request.UserDto.Id);

                    return null;

                default:
                    throw new NotImplementedException();
            }
        }
    }
}
