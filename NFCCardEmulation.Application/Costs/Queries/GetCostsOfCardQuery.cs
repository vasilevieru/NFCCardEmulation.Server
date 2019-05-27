using MediatR;
using NFCCardEmulation.Application.Costs.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace NFCCardEmulation.Application.Costs.Queries
{
    public class GetCostsOfCardQuery : IRequest<CostOfCardListViewModel>
    {
        public int UserId { get; set; }
        public int CardId { get; set; }
    }
}
