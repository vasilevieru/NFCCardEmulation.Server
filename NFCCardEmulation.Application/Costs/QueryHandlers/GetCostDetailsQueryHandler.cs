using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using NFCCardEmulation.Application.Costs.Models;
using NFCCardEmulation.Application.Costs.Queries;
using NFCCardEmulation.Application.Exceptions;
using NFCCardEmulation.Application.Interfaces;
using NFCCardEmulation.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace NFCCardEmulation.Application.Costs.QueryHandlers
{
    public class GetCostDetailsQueryHandler : IRequestHandler<GetCostDetailsQuery, CostDetailsModel>
    {
        private readonly INFCCardEmulationDbContext _context;
        private readonly IMapper _mapper;

        public GetCostDetailsQueryHandler(INFCCardEmulationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<CostDetailsModel> Handle(GetCostDetailsQuery request, CancellationToken cancellationToken)
        {
            var cost = _mapper.Map<CostDetailsModel>(await _context.Costs
                .Where(x => x.Id == request.Id)
                .SingleOrDefaultAsync(cancellationToken));

            if (cost == null)
                throw new NotFoundException(nameof(Cost), request.Id);

            return cost;
        }
    }
}