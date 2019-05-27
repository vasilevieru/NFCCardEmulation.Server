using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using NFCCardEmulation.Application.Interfaces;
using NFCCardEmulation.Application.Shops.Models;
using NFCCardEmulation.Application.Shops.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace NFCCardEmulation.Application.Shops.QueryHandlers
{
    public class GetShopsQueryHandler : IRequestHandler<GetShopsQuery, ShopListViewModel>
    {
        private readonly INFCCardEmulationDbContext _context;
        private readonly IMapper _mapper;

        public GetShopsQueryHandler(INFCCardEmulationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<ShopListViewModel> Handle(GetShopsQuery request, CancellationToken cancellationToken)
        {
            var shops = await _context.Shops.ToListAsync();

            var model = new ShopListViewModel
            {
                Shops = _mapper.Map<IEnumerable<ShopDetailsModel>>(shops)
            };

            return model;
        }
    }
}
