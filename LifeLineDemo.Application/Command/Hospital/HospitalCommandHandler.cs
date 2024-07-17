using AutoMapper;
using LifeLineDemo.Domain.DTO;
using LifeLineDemo.Domain.Entities;
using LifeLineDemo.Domain.Enums;
using LifeLineDemo.Domain.Interface;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LifeLineDemo.Application.Command.hospital
{
    public class HospitalCommandHandler : IRequestHandler<HospitalCommand, HospitalDto>
    {
        private readonly IRepo repo;
        private readonly IMapper mapper;

        public HospitalCommandHandler(IRepo repo,IMapper mapper) 
        {
            this.repo = repo;
            this.mapper = mapper;
        }
        public  async Task<HospitalDto> Handle(HospitalCommand request, CancellationToken cancellationToken)
        {
            Hospital hospital;
            switch (request.Operation)
            {
                case Operation.Create:
                    {
                        hospital = new Hospital
                        {
                            Name=request.HospitalNoIdDto.Name,
                            Address=request.HospitalNoIdDto.Address,
                            Email=request.HospitalNoIdDto.Email,
                            PhoneNumber=request.HospitalNoIdDto.PhoneNumber,
                            City=request.HospitalNoIdDto.City,
                            ZipCode=request.HospitalNoIdDto.ZipCode,
                            State=request.HospitalNoIdDto.State,
                            AmbulanceCount=request.HospitalNoIdDto.AmbulanceCount,
                            EmergencyServicesAvailable=request.HospitalNoIdDto.EmergencyServicesAvailable,
                            Specializations=request.HospitalNoIdDto.Specializations,
                            Rating=request.HospitalNoIdDto.Rating,
                            Longitude=request.HospitalNoIdDto.Longitude,
                            Latitude=request.HospitalNoIdDto.Latitude
                            
                            
                        }; 
                        var newhospital=await repo.CreateHospital( hospital );
                        return mapper.Map<HospitalDto>( newhospital );
                    }
                case Operation.Update:
                    {
                        var updatehospital = new Hospital
                        {
                            Id=request.HospitalDto.Id,
                            Name = request.HospitalDto.Name,
                            Address = request.HospitalDto.Address,
                            Email = request.HospitalDto.Email,
                            PhoneNumber = request.HospitalDto.PhoneNumber,
                            City = request.HospitalDto.City,
                            ZipCode = request.HospitalDto.ZipCode,
                            State = request.HospitalDto.State,
                            AmbulanceCount = request.HospitalDto.AmbulanceCount,
                            EmergencyServicesAvailable = request.HospitalDto.EmergencyServicesAvailable,
                            Specializations = request.HospitalDto.Specializations,
                            Rating = request.HospitalDto.Rating,
                            Longitude = request.HospitalDto.Longitude,
                            Latitude = request.HospitalDto.Latitude
                        };
                        var updatedhospital=await repo.UpdateHospital(request.HospitalDto.Id, updatehospital);
                        return mapper.Map<HospitalDto>(updatedhospital);
                    }
                    case Operation.Delete: 
                    { 
                        var deleteid=await repo.DeleteHospital(request.HospitalDto.Id);
                        return null;
                    }
                    default:throw new ArgumentOutOfRangeException();

            }

        }
    }
}
