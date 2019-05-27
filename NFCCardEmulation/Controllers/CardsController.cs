using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
        public async Task<ActionResult> GetById(int id)
        {
            return Ok(await Mediator.Send(new GetCardDetailsQuery { Id = id }));
        }


    }
}