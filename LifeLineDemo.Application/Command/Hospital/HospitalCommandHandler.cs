using AutoMapper;
using LifeLineDemo.Domain.DTO;
using LifeLineDemo.Domain.Interface;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LifeLineDemo.Application.Command.Hospital
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
        public async Task<HospitalDto> Handle(HospitalCommand request, CancellationToken cancellationToken)
        {
            
        }
    }
}
