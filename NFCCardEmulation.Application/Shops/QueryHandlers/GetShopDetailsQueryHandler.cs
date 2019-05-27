using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using NFCCardEmulation.Application.Exceptions;
using NFCCardEmulation.Application.Interfaces;
using NFCCardEmulation.Application.Shops.Models;
using NFCCardEmulation.Application.Shops.Queries;
using NFCCardEmulation.Domain.Entities;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace NFCCardEmulation.Application.Shops.QueryHandlers
{
    public class GetShopDetailsQueryHandler : IRequestHandler<GetShopDetailsQuery, ShopDetailsModel>
    {
        private readonly INFCCardEmulationDbContext _context;
        private readonly IMapper _mapper;

        public GetShopDetailsQueryHandler(INFCCardEmulationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ShopDetailsModel> Handle(GetShopDetailsQuery request, CancellationToken cancellationToken)
        {
            var shop = _mapper.Map<ShopDetailsModel>(await _context.Shops
                .Where(x => x.Id == request.Id)
                .SingleOrDefaultAsync(cancellationToken));

            if (shop == null)
                throw new NotFoundException(nameof(Shop), request.Id);

            return shop;
        }
    }
}
