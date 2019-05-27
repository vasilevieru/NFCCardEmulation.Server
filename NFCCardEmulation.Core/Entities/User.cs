using System;
using System.Collections.Generic;
using System.Text;

namespace NFCCardEmulation.Domain.Entities
{
    public class User : BaseEntity
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public ICollection<Card> Cards { get; set; }
    }
}
