using System;
using System.Collections.Generic;
using System.Text;

namespace NFCCardEmulation.Domain.Entities
{
    public class Card : BaseEntity
    {
        public string Number { get; set; }
        public string CVV { get; set; }
        public DateTime Expiration { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public ICollection<Cost> Costs { get; set; }
    }
}
