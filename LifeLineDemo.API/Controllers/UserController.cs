using LifeLineDemo.Application.Command.Users;
using LifeLineDemo.Domain.DTO;
using LifeLineDemo.Domain.Enums;
using LifeLineDemo.Domain.Interface.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace LifeLineDemo.API.Controllers
{
    [Route("API/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IGetUser getUser;
        private readonly IMediator mediator;

        public UserController(IGetUser getUser, IMediator mediator)
        {
            this.getUser = getUser;
            this.mediator = mediator;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var user = getUser.GetAllUsers();
            return Ok(user);
        }

        [HttpGet("Id")]
        public IActionResult GetById(long id)
        {
            var user = getUser.GetUserById(id);
            return Ok(user);
        }

        [HttpPost]

        public async Task<IActionResult> Create(UserNoIdDto user)
        {
            var command = new UserCommand(Operation.Create, user);

            var res = await mediator.Send(command);
            return Ok(res);
        }

        [HttpPut("{id}")]

        public async Task<IActionResult> Update(long id, UserDto user)
        {
            if (id != user.Id)
            {
                return BadRequest();
            }
            var command = new UserCommand(Operation.Update, user);

            var res = await mediator.Send(command);
            return Ok(res);
        }
        [HttpDelete("{id}")]

        public async Task<IActionResult> Update(long id)
        {

            var user = new UserDto { Id = id };
            var command = new UserCommand(Operation.Delete, user);

            var res = await mediator.Send(command);
            return Ok(new { message = "User deleted successfully" });
        }
    }
}
