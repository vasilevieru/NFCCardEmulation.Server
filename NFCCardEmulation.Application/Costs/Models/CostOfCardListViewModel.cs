using System;
using System.Collections.Generic;
using System.Text;

namespace NFCCardEmulation.Application.Costs.Models
{
    public class CostOfCardListViewModel
    {
        public IEnumerable<CostsOfCardViewModel> CostsOfCards { get; set; }
    }
}
