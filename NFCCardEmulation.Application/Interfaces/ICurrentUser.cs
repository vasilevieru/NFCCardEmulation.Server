using System;
using System.Collections.Generic;
using System.Text;

namespace NFCCardEmulation.Application.Interfaces
{
    public interface ICurrentUser
    {
        int UserId { get; }
    }
}
