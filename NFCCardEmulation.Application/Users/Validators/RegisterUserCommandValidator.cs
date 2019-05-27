using FluentValidation;
using NFCCardEmulation.Application.Users.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace NFCCardEmulation.Application.Users.Validators
{
    public class RegisterUserCommandValidator : AbstractValidator<RegisterUserCommand>
    {
        public RegisterUserCommandValidator()
        {
            RuleFor(x => x.Name).MaximumLength(100).NotEmpty();
            RuleFor(x => x.Email).MaximumLength(100).NotEmpty();
            RuleFor(x => x.Password).MaximumLength(50).NotEmpty();
        }
    }
}
