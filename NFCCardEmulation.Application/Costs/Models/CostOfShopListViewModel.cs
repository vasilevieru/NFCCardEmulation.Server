using System;
using System.Collections.Generic;
using System.Text;

namespace NFCCardEmulation.Application.Costs.Models
{
    public class CostOfShopListViewModel
    {
        public IEnumerable<CostsOfShopViewModel> CostsOfShops { get; set; }
    }
}
