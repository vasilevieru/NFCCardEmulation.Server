using MediatR;
using NFCCardEmulation.Application.Cards.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace NFCCardEmulation.Application.Cards.Queries
{
    public class GetCardsQuery : IRequest<CardListViewModel>
    {
        public int UserId { get; set; }
    }
}
