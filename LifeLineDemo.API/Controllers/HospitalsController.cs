using LifeLineDemo.Application.Command.hospital;
using LifeLineDemo.Domain.DTO;
using LifeLineDemo.Domain.Enums;
using LifeLineDemo.Domain.Interface.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace LifeLineDemo.API.Controllers
{
    [Route("API/[controller]")]
    [ApiController]
    public class HospitalsController : ControllerBase
    {
        private readonly IGetHospital getHospital;
        private readonly IMediator mediator;

        public HospitalsController(IGetHospital getHospital, IMediator mediator)
        {
            this.getHospital = getHospital;
            this.mediator = mediator;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var hospital = getHospital.GetHospitalList();
            return Ok(hospital);
        }

        [HttpGet("Id")]
        public IActionResult GetById(long id)
        {
            var hospital = getHospital.GetHospitalById(id);
            return Ok(hospital);
        }

        [HttpPost]

        public async Task<IActionResult> Create(HospitalNoIdDto hospital)
        {
            var command = new HospitalCommand(Operation.Create, hospital);

            var res = await mediator.Send(command);
            return Ok(res);
        }

        [HttpPut("{id}")]

        public async Task<IActionResult> Update(long id, HospitalDto hospital)
        {
            if (id != hospital.Id)
            {
                return BadRequest();
            }
            var command = new HospitalCommand(Operation.Update, hospital);

            var res = await mediator.Send(command);
            return Ok(res);
        }
        [HttpDelete("{id}")]

        public async Task<IActionResult> Update(long id)
        {

            var hospital = new HospitalDto { Id = id };
            var command = new HospitalCommand(Operation.Delete, hospital);

            var res = await mediator.Send(command);
            return Ok(new { message = "User-Roles deleted successfully" });
        }
    }
}
