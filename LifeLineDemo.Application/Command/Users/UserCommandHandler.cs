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
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public UserCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
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
                        FirstName = request.UserNoIdDto.FirstName,
                        LastName = request.UserNoIdDto.LastName,
                        AddressLine1 = request.UserNoIdDto.AddressLine1,
                        AddressLine2 = request.UserNoIdDto.AddressLine2,
                        Pincode = request.UserNoIdDto.Pincode,
                        Gender = request.UserNoIdDto.Gender,
                        BloodGroup = request.UserNoIdDto.BloodGroup,
                        Dob = request.UserNoIdDto.Dob,
                        PhoneNumber = request.UserNoIdDto.PhoneNumber,
                        Email = request.UserNoIdDto.Email,
                        IsAvailable = request.UserNoIdDto.IsAvailable,
                        LicenseNumber = request.UserNoIdDto.LicenseNumber,
                        LicenseExpiryDate = request.UserNoIdDto.LicenseExpiryDate,
                        RoleId = request.UserNoIdDto.RoleId
                    };
                    var createUsers = await unitOfWork._userRepo.Create(user);
                    return mapper.Map<UserDto>(createUsers);

                case Operation.Update:

                    var updateUser = new User
                    {
                        Id = request.UserDto.Id,
                        FirstName = request.UserDto.FirstName,
                        LastName = request.UserDto.LastName,
                        AddressLine1 = request.UserDto.AddressLine1,
                        AddressLine2 = request.UserDto.AddressLine2,
                        Pincode = request.UserDto.Pincode,
                        Gender = request.UserDto.Gender,
                        BloodGroup = request.UserDto.BloodGroup,
                        Dob = request.UserDto.Dob,
                        PhoneNumber = request.UserDto.PhoneNumber,
                        Email = request.UserDto.Email,
                        IsAvailable = request.UserDto.IsAvailable,
                        LicenseNumber = request.UserDto.LicenseNumber,
                        LicenseExpiryDate = request.UserDto.LicenseExpiryDate,
                        RoleId = request.UserDto.RoleId
                    };
                    await unitOfWork._userRepo.Update(request.UserDto.Id, updateUser);
                    return mapper.Map<UserDto>(updateUser);

                case Operation.Delete:

                    await unitOfWork._userRepo.Delete(request.UserDto.Id);

                    return null;

                default:
                    throw new NotImplementedException();
            }
        }
    }
}
