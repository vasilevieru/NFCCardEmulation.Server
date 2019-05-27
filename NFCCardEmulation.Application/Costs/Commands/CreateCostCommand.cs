using MediatR;
using NFCCardEmulation.Application.Costs.Models;

namespace NFCCardEmulation.Application.Costs.Commands
{
    public class CreateCostCommand : IRequest<CostDetailsModel>
    {
        public double Price { get; set; }
        public int ShopId { get; set; }
        public int CardId { get; set; }
    }
}
