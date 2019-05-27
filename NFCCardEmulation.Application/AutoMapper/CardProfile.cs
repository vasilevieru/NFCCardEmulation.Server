using AutoMapper;
using NFCCardEmulation.Application.Cards.Commands;
using NFCCardEmulation.Application.Cards.Models;
using NFCCardEmulation.Domain.Entities;

namespace NFCCardEmulation.Application.AutoMapper
{
    public class CardProfile : Profile
    {
        public CardProfile()
        {
            CreateMap<CreateCardCommand, Card>();
            CreateMap<Card, CardDetailsModel>();
        }
    }
}
