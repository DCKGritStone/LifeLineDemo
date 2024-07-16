using LifeLineDemo.Application.Command.UserRole;
using LifeLineDemo.Domain.DTO;
using LifeLineDemo.Domain.Enums;
using LifeLineDemo.Domain.Interface.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace LifeLineDemo.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserRolesController : ControllerBase
    {
        private readonly IGetUserRoles getUserRoles;
        private readonly IMediator mediator;

        public UserRolesController(IGetUserRoles getUserRoles, IMediator mediator)
        {
            this.getUserRoles = getUserRoles;
            this.mediator = mediator;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var userRole = getUserRoles.GetAllUserRoles();
            return Ok(userRole);
        }

        [HttpGet("Id")]
        public IActionResult GetById(long id)
        {
            var userRole = getUserRoles.GetUserRoleById(id);
            return Ok(userRole);
        }

        [HttpPost]

        public async Task<IActionResult> Create(UserRolesNoIdDto userRoles)
        {
            var command = new UserRolesCommand(Operation.Create, userRoles);

            var res = await mediator.Send(command);
            return Ok(res);
        }

        [HttpPut("{id}")]

        public async Task<IActionResult> Update(long id, UserRolesDto userRoles)
        {
            if (id != userRoles.Id)
            {
                return BadRequest();
            }
            var command = new UserRolesCommand(Operation.Update, userRoles);

            var res = await mediator.Send(command);
            return Ok(res);
        }
        [HttpPut("{id}")]

        public async Task<IActionResult> Update(long id)
        {

            var userRoles = new UserRolesDto { Id = id };
            var command = new UserRolesCommand(Operation.Delete, userRoles);

            var res = await mediator.Send(command);
            return Ok(new { message = "User-Roles deleted successfully" });
        }
    }
}