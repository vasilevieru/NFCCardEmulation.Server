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
        }
    }
}
