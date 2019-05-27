using MediatR;
using NFCCardEmulation.Application.Costs.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace NFCCardEmulation.Application.Costs.Queries
{
    public class GetCostDetailsQuery : IRequest<CostDetailsModel>
    {
        public int Id { get; set; }
    }
}
