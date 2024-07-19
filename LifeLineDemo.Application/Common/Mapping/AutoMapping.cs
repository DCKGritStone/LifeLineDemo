using AutoMapper;
using LifeLineDemo.Domain.DTO;
using LifeLineDemo.Domain.Entities;

namespace LifeLineDemo.Application.Comman.Mapping
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            CreateMap<Role, RoleDto>().ReverseMap();
            CreateMap<UserRoles, UserRolesDto>().ReverseMap();
            CreateMap<User, UserDto>().ReverseMap();
            CreateMap<Role, RoleNoIdDto>().ReverseMap();
            CreateMap<UserRoles, UserRolesNoIdDto>().ReverseMap();
            CreateMap<User, UserNoIdDto>().ReverseMap();
            CreateMap<Hospital, HospitalDto>().ReverseMap();
            CreateMap<Hospital, HospitalNoIdDto>().ReverseMap();
        }
    }
}
