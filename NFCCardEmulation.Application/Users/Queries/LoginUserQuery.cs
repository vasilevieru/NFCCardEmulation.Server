using MediatR;
using NFCCardEmulation.Application.Users.Models;

namespace NFCCardEmulation.Application.Users.Queries
{
    public class LoginUserQuery : IRequest<LoginUserModel>
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
