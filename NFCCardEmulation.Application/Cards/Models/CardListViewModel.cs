using System;
using System.Collections.Generic;
using System.Text;

namespace NFCCardEmulation.Application.Cards.Models
{
    public class CardListViewModel
    {
        public IEnumerable<CardDetailsModel> Cards { get; set; }
    }
}
