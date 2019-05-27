using MediatR;
using NFCCardEmulation.Application.Cards.Models;

namespace NFCCardEmulation.Application.Cards.Queries
{
    public class GetCardDetailsQuery : IRequest<CardDetailsModel>
    {
        public int Id { get; set; }
    }
}
