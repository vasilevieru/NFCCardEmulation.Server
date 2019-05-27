using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using NFCCardEmulation.Application.Cards.Commands;
using NFCCardEmulation.Application.Cards.Queries;

namespace NFCCardEmulation.Controllers
{
    [Route("api/[controller]")]
    public class CardsController : BaseController
    {
        private readonly IMediator _mediator;

        public CardsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await Mediator.Send(new GetCardDetailsQuery { Id = id }));
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateCardCommand command)
        {
            var card = await Mediator.Send(command);

            return CreatedAtAction(nameof(GetById), new { card.Id }, card);
        }

    }
}