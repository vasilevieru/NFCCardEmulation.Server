using System;
using System.Collections.Generic;
using System.Text;

namespace NFCCardEmulation.Domain.Entities
{
    public class Cost : BaseEntity
    {
        public double Price { get; set; }
        public int ShopId { get; set; }
        public Shop Shop { get; set; }
        public int CardId { get; set; }
        public Card Card { get; set; }
    }
}
