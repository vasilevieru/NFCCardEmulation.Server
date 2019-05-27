using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using NFCCardEmulation.Application.Users.Commands;
using NFCCardEmulation.Application.Users.Queries;

namespace NFCCardEmulation.Controllers
{
    [Route("api/[controller]")]
    public class UsersController : BaseController
    {
        private readonly IMediator _mediator;

        public UsersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetById(int id)
        {
            return Ok(await Mediator.Send(new GetUserDetailsQuery { Id = id }));
        }

        [HttpPost("registration")]
        public async Task<IActionResult> Registration([FromBody] RegisterUserCommand command)
        {
            var user = await Mediator.Send(command);

            return CreatedAtAction(nameof(GetById), new { user.Id }, user);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginUserQuery query)
        {
            var user = await Mediator.Send(query);

            return Ok(user);
        }
    }
}