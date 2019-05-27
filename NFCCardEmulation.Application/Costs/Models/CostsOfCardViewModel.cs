using System;
using System.Collections.Generic;
using System.Text;

namespace NFCCardEmulation.Application.Costs.Models
{
    public class CostsOfCardViewModel
    {
        public double Price { get; set; }
        public int CardId { get; set; }
        public string CardNumber { get; set; }
    }
}
