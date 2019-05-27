using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using NFCCardEmulation.Application.Shops.Queries;

namespace NFCCardEmulation.Controllers
{
    [Route("api/[controller]")]
    public class ShopsController : BaseController
    {
        private readonly IMediator _mediator;

        public ShopsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await Mediator.Send(new GetShopsQuery()));
        }
    }
}