using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using NFCCardEmulation.Application.Costs.Models;
using NFCCardEmulation.Application.Costs.Queries;
using NFCCardEmulation.Application.Interfaces;

namespace NFCCardEmulation.Application.Costs.QueryHandlers
{
    public class GetCostsQueryHandler : IRequestHandler<GetCostsQuery, CostListViewModel>
    {
        private readonly INFCCardEmulationDbContext _context;
        private readonly IMapper _mapper;

        public GetCostsQueryHandler(INFCCardEmulationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<CostListViewModel> Handle(GetCostsQuery request, CancellationToken cancellationToken)
        {
            var costs = await _context.Costs
                .Include(x => x.Card)
                .Where(x => x.Card.UserId == request.UserId)
                .ToListAsync();

            var model = new CostListViewModel
            {
                Costs = _mapper.Map<IEnumerable<CostDetailsModel>>(costs)
            };

            return model;
        }
    }
}
