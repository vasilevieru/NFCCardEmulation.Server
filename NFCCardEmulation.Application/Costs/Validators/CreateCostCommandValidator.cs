using FluentValidation;
using NFCCardEmulation.Application.Costs.Commands;

namespace NFCCardEmulation.Application.Costs.Validators
{
    public class CreateCostCommandValidator : AbstractValidator<CreateCostCommand>
    {
        public CreateCostCommandValidator()
        {
            RuleFor(x => x.Price).NotNull();
            RuleFor(x => x.ShopId).NotNull();
            RuleFor(x => x.CardId).NotNull();
        }
    }
}
