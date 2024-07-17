using LifeLineDemo.Domain.DTO;
using LifeLineDemo.Domain.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LifeLineDemo.Application.Command.Hospital
{
    public class HospitalCommand:IRequest<HospitalDto>
    {
        public HospitalCommand(Operation operation,HospitalDto hospitalDto)
        {
            Operation = operation;
            HospitalDto = hospitalDto;
        }
        public HospitalCommand(Operation operation,HospitalNoIdDto hospitalNoIdDto)
        {
            Operation = operation;
            HospitalNoIdDto = hospitalNoIdDto;
        }

        public Operation Operation { get; }
        public HospitalNoIdDto HospitalNoIdDto { get; }
        public HospitalDto HospitalDto { get; }
    }
}
