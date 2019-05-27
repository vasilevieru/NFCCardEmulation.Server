using MediatR;
using NFCCardEmulation.Application.Cards.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace NFCCardEmulation.Application.Cards.Commands
{
    public class CreateCardCommand : IRequest<CardDetailsModel>
    {
        public string Number { get; set; }
        public string CVV { get; set; }
        public DateTime Expiration { get; set; }
        public int UserId { get; set; }
    }
}
