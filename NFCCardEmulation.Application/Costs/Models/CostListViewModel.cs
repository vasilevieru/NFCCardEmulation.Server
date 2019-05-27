using System;
using System.Collections.Generic;
using System.Text;

namespace NFCCardEmulation.Application.Costs.Models
{
    public class CostListViewModel
    {
        public IEnumerable<CostDetailsModel> Costs { get; set; }
    }
}
