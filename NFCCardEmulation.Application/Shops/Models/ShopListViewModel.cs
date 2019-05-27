using System;
using System.Collections.Generic;
using System.Text;

namespace NFCCardEmulation.Application.Shops.Models
{
    public class ShopListViewModel
    {
        public IEnumerable<ShopDetailsModel> Shops { get; set; }
    }
}
