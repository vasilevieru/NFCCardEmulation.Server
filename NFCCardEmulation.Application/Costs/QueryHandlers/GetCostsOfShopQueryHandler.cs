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
    public class GetCostsOfShopQueryHandler : IRequestHandler<GetCostsOfShopQuery, CostOfShopListViewModel>
    {
        private readonly INFCCardEmulationDbContext _context;
        private readonly IMapper _mapper;

        public GetCostsOfShopQueryHandler(INFCCardEmulationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<CostOfShopListViewModel> Handle(GetCostsOfShopQuery request, CancellationToken cancellationToken)
        {
            var costs = await _context.Costs
                .Include(x => x.Card)
                .Where(x => x.ShopId == request.ShopId && x.Card.UserId == request.UserId)
                .ToListAsync();

            var model = new CostOfShopListViewModel
            {
                CostsOfShops = _mapper.Map<IEnumerable<CostsOfShopViewModel>>(costs)
            };

            return model;
        }
    }
}
