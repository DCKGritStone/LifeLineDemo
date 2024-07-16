using LifeLineDemo.Application.Command.Roles;
using LifeLineDemo.Domain.DTO;
using LifeLineDemo.Domain.Enums;
using LifeLineDemo.Domain.Interface.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace LifeLineDemo.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolesController : ControllerBase
    {
        private readonly IGetRole getRole;
        private readonly IMediator mediator;

        public RolesController(IGetRole getRole, IMediator mediator)
        {
            this.getRole = getRole;
            this.mediator = mediator;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var role = getRole.GetAllRoles();
            return Ok(role);
        }

        [HttpGet("Id")]
        public IActionResult GetById(long id)
        {
            var role = getRole.GetRoleById(id);
            return Ok(role);
        }

        [HttpPost]

        public async Task<IActionResult> Create(RoleNoIdDto role)
        {
            var command = new RoleCommand(Operation.Create, role);

            var res = await mediator.Send(command);
            return Ok(res);
        }

        [HttpPut("{id}")]

        public async Task<IActionResult> Update(long id, RoleDto role)
        {
            if (id != role.Id)
            {
                return BadRequest();
            }
            var command = new RoleCommand(Operation.Update, role);

            var res = await mediator.Send(command);
            return Ok(res);
        }
        [HttpPut("{id}")]

        public async Task<IActionResult> Update(long id)
        {

            var role = new RoleDto { Id = id };
            var command = new RoleCommand(Operation.Delete, role);

            var res = await mediator.Send(command);
            return Ok(new { message = "Credentials deleted successfully" });
        }

    }
}
