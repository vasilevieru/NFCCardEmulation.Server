using FluentValidation;
using NFCCardEmulation.Application.Cards.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace NFCCardEmulation.Application.Cards.Validators
{
    public class CreateCardCommandValidator : AbstractValidator<CreateCardCommand>
    {
        public CreateCardCommandValidator()
        {
            RuleFor(x => x.Number).MaximumLength(16).MaximumLength(16).NotEmpty();
            RuleFor(x => x.CVV).MaximumLength(3).MaximumLength(3).NotEmpty();
            RuleFor(x => x.Expiration).NotEmpty();
            RuleFor(x => x.UserId).NotNull();
        }
    }
}
