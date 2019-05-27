using System;
using System.Collections.Generic;
using System.Text;

namespace NFCCardEmulation.Domain.Entities
{
    public class Shop : BaseEntity
    {
        public string Name { get; set; }
        public string Category { get; set; }
        public ICollection<Cost> Costs { get; set; }
    }
}
