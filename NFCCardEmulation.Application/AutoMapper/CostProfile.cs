using AutoMapper;
using NFCCardEmulation.Application.Costs.Commands;
using NFCCardEmulation.Application.Costs.Models;
using NFCCardEmulation.Domain.Entities;

namespace NFCCardEmulation.Application.AutoMapper
{
    public class CostProfile : Profile
    {
        public CostProfile()
        {
            CreateMap<CreateCostCommand, Cost>();
            CreateMap<Cost, CostDetailsModel>();

            CreateMap<Cost, CostsOfShopViewModel>()
                .ForMember(dest => dest.ShopName, src => src.MapFrom(x => x.Shop.Name));

            CreateMap<Cost, CostsOfCardViewModel>()
                .ForMember(dest => dest.CardNumber, src => src.MapFrom(x => x.Card.Number));
        }
    }
}
