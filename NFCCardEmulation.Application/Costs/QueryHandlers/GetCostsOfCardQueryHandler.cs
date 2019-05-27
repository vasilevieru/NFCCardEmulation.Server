using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using NFCCardEmulation.Application.Costs.Models;
using NFCCardEmulation.Application.Costs.Queries;
using NFCCardEmulation.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace NFCCardEmulation.Application.Costs.QueryHandlers
{
    public class GetCostsOfCardQueryHandler : IRequestHandler<GetCostsOfCardQuery, CostOfCardListViewModel>
    {
        private readonly INFCCardEmulationDbContext _context;
        private readonly IMapper _mapper;

        public GetCostsOfCardQueryHandler(INFCCardEmulationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<CostOfCardListViewModel> Handle(GetCostsOfCardQuery request, CancellationToken cancellationToken)
        {
            var costs = await _context.Costs
                 .Include(x => x.Card)
                 .Where(x => x.CardId == request.CardId && x.Card.UserId == request.UserId)
                 .ToListAsync();

            var model = new CostOfCardListViewModel
            {
                CostsOfCards = _mapper.Map<IEnumerable<CostsOfCardViewModel>>(costs)
            };

            return model;
        }
    }
}
