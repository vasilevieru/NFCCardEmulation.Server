using MediatR;
using Microsoft.AspNetCore.Mvc;
using NFCCardEmulation.Application.Costs.Commands;
using NFCCardEmulation.Application.Costs.Queries;
using System.Threading.Tasks;

namespace NFCCardEmulation.Controllers
{
    [Route("api/[controller]")]
    public class CostsController : BaseController
    {
        private readonly IMediator _mediator;

        public CostsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await Mediator.Send(new GetCostsQuery()));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await Mediator.Send(new GetCostDetailsQuery { Id = id }));
        }

        [HttpGet("shop")]
        public async Task<IActionResult> GetCostsOfShop([FromQuery]int userId, [FromQuery]int shopId)
        {
            return Ok(await Mediator.Send(new GetCostsOfShopQuery { UserId = userId, ShopId = shopId }));
        }

        [HttpGet("card")]
        public async Task<IActionResult> GetCostsOfCard([FromQuery]int userId, [FromQuery]int cardId)
        {
            return Ok(await Mediator.Send(new GetCostsOfCardQuery { UserId = userId, CardId = cardId }));
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateCostCommand command)
        {
            var cost = await Mediator.Send(command);

            return CreatedAtAction(nameof(GetById), new { cost.Id }, cost);
        }

    }
}