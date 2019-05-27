using MediatR;
using NFCCardEmulation.Application.Users.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace NFCCardEmulation.Application.Users.Queries
{
    public class GetUserDetailsQuery : IRequest<UserDetailsModel>
    {
        public int Id { get; set; }
    }
}
