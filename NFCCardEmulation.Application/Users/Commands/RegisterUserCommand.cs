using MediatR;
using NFCCardEmulation.Application.Users.Models;

namespace NFCCardEmulation.Application.Users.Commands
{
    public class RegisterUserCommand : IRequest<UserDetailsModel>
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
