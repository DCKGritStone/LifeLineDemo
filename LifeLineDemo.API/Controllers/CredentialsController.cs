using LifeLineDemo.Application.Command.Credentail;
using LifeLineDemo.Domain.DTO;
using LifeLineDemo.Domain.Enums;
using LifeLineDemo.Domain.Interface.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace LifeLineDemo.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CredentialsController : ControllerBase
    {
        private readonly IGetCredentials getCredentials;
        private readonly IMediator mediator;

        public CredentialsController(IGetCredentials getCredentials, IMediator mediator)
        {
            this.getCredentials = getCredentials;
            this.mediator = mediator;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var cred = getCredentials.GetAllCredentials();
            return Ok(cred);
        }

        [HttpGet("Id")]
        public IActionResult GetById(long id)
        {
            var cred = getCredentials.GetCerdentialById(id);
            return Ok(cred);
        }

        [HttpPost]

        public async Task<IActionResult> Create(CredNoIdDto cred)
        {
            var command = new CredentialsCommand(Operation.Create, cred);

            var res = await mediator.Send(command);
            return Ok(res);
        }

        [HttpPut("{id}")]

        public async Task<IActionResult> Update(long id, CredDto cred)
        {
            if (id != cred.Id)
            {
                return BadRequest();
            }
            var command = new CredentialsCommand(Operation.Update, cred);

            var res = await mediator.Send(command);
            return Ok(res);
        }
        [HttpPut("{id}")]

        public async Task<IActionResult> Update(long id)
        {

            var cred = new CredDto { Id = id };
            var command = new CredentialsCommand(Operation.Delete, cred);

            var res = await mediator.Send(command);
            return Ok(new { message = "Credentials deleted successfully" });
        }

    }
}
