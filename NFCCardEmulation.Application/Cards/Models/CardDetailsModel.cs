using System;
using System.Collections.Generic;
using System.Text;

namespace NFCCardEmulation.Application.Cards.Models
{
    public class CardDetailsModel
    {
        public int Id { get; set; }
        public string Number { get; set; }
        public string CVV { get; set; }
        public DateTime Expiration { get; set; }
    }
}
